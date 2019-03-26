using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EnvDTE;
using Microsoft.VisualStudio.ComponentModelHost;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Ultramarine.Generators.Serialization.Providers;
using Ultramarine.Workspaces.VisualStudio;
using Task = System.Threading.Tasks.Task;

namespace Ultramarine.VSExtension.Commands
{
    /// <summary>
    /// Command handler
    /// </summary>
    internal sealed class ProjectGeneratorCommand
    {
        private const string ProjectGeneratorXmlConfigurationFileName = "Project.gen.config";
        private const string ProjectGeneratorJsonConfigurationFileName = "Project.gen.json";

        /// <summary>
        /// Command ID.
        /// </summary>
        public const int CommandId = 0x0100;

        /// <summary>
        /// Command menu group (command set GUID).
        /// </summary>
        public static readonly Guid CommandSet = new Guid("97179d86-fae6-42ba-bb5f-f746f3ba384b");

        /// <summary>
        /// VS Package that provides this command, not null.
        /// </summary>
        private readonly AsyncPackage package;


        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectGeneratorCommand"/> class.
        /// Adds our command handlers for menu (commands must exist in the command table file)
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        /// <param name="commandService">Command service to add command to, not null.</param>
        private ProjectGeneratorCommand(AsyncPackage package, OleMenuCommandService commandService)
        {
            this.package = package ?? throw new ArgumentNullException(nameof(package));
            commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));

            var menuCommandID = new CommandID(CommandSet, CommandId);
            var menuItem = new OleMenuCommand(this.Execute, menuCommandID);
            menuItem.Enabled = false;
            menuItem.BeforeQueryStatus += OnProjectGeneratorReady;
            commandService.AddCommand(menuItem);
        }

        private async void OnProjectGeneratorReady(object sender, EventArgs e)
        {
            var menuCommand = (OleMenuCommand)sender;            
            menuCommand.Enabled = await HasConfigurationAsync(ProjectGeneratorXmlConfigurationFileName) || await HasConfigurationAsync(ProjectGeneratorJsonConfigurationFileName);

        }

        private async Task<bool> HasConfigurationAsync(string configurationName)
        {
            var selectedProjects = await GetSelectedProjectsAsync();
            var selectedProjectItems = await FindProjectConfigurationItemsAsync(selectedProjects, configurationName);
            return selectedProjectItems.Any();
        }
        private async Task<List<ProjectItem>> FindProjectConfigurationItemsAsync(List<Project> projects, string configurationName)
        {
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();
            var projectItems = new List<ProjectItem>();
            foreach (var project in projects)
            {
                for (var i = 1; i < project.ProjectItems.Count; i++)
                {
                    var item = project.ProjectItems.Item(i);
                    if (item.Name == configurationName)
                    {
                        projectItems.Add(item);
                    }
                }
            }

            return projectItems;
        }

        private async Task<List<Project>> GetSelectedProjectsAsync()
        {
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync(package.DisposalToken);

            var selectedProjects = new List<Project>();

            if (!(await ServiceProvider.GetServiceAsync(typeof(SDTE)) is DTE dte))
                return null;

            var selectedItems = dte.SelectedItems;
            if (selectedItems.MultiSelect)
                for (var i = 1; i < selectedItems.Count; i++)
                {
                    var selectedItem = selectedItems.Item(i);
                    if (selectedItem.Project is Project)
                        selectedProjects.Add(selectedItem.Project);
                }
            else
            {
                var selectedItem = selectedItems.Item(1);
                if (selectedItem.Project is Project)
                    selectedProjects.Add(selectedItem.Project);
            }

            return selectedProjects;
        }

        /// <summary>
        /// Gets the instance of the command.
        /// </summary>
        public static ProjectGeneratorCommand Instance
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the service provider from the owner package.
        /// </summary>
        private Microsoft.VisualStudio.Shell.IAsyncServiceProvider ServiceProvider
        {
            get
            {
                return this.package;
            }
        }

        /// <summary>
        /// Initializes the singleton instance of the command.
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        public static async Task InitializeAsync(AsyncPackage package)
        {
            // Switch to the main thread - the call to AddCommand in GeneratorCommand's constructor requires
            // the UI thread.
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync(package.DisposalToken);
            OleMenuCommandService commandService = await package.GetServiceAsync((typeof(IMenuCommandService))) as OleMenuCommandService;
            Instance = new ProjectGeneratorCommand(package, commandService);
            await Dte.Instance.InitializeAsync(package);
        }

        /// <summary>
        /// This function is the callback used to execute the command when the menu item is clicked.
        /// See the constructor to see how the menu item is associated with this function using
        /// OleMenuCommandService service and MenuCommand class.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event args.</param>
        private void Execute(object sender, EventArgs e)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            //string message = string.Format(CultureInfo.CurrentCulture, "Inside {0}.MenuItemCallback()", this.GetType().FullName);
            //string title = "GeneratorCommand";
            var host = ServiceProvider.GetServiceAsync(typeof(SDTE)).Result as DTE;
            if (host.SelectedItems.MultiSelect)
            {
                VsShellUtilities.ShowMessageBox(
                    this.package,
                    "Multiple selected items are currently not supported.",
                    "Information",
                    OLEMSGICON.OLEMSGICON_INFO,
                    OLEMSGBUTTON.OLEMSGBUTTON_OK,
                    OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);
                MessageBox.Show("Multiple selected items are currently not supported", "Information");
                return;
            }

            var selectedItem = host.SelectedItems.Item(1);
            if (selectedItem == null)
                return;
            var selectedProject = selectedItem.Project;

            var projectPath = selectedProject.Properties.Item("FullPath").Value.ToString();

            ////TODO: test purposes only
            //var componentModel = (IComponentModel)ServiceProvider.GetServiceAsync(typeof(SComponentModel)).Result;
            //var workspace = componentModel.GetService<Microsoft.VisualStudio.LanguageServices.VisualStudioWorkspace>();

            //var project = workspace.CurrentSolution.Projects.First(c => c.Name == selectedProject.Name);
            
            var generatorPath = Path.Combine(Path.GetDirectoryName(projectPath), "Project.gen.json");
            var generator = GeneratorSerializer.Instance.Load(generatorPath);
            generator.SetExecutionContext(new ProjectModel(selectedProject));
            generator.SetLogger(new OutputLogger());
            
            generator.Execute();
            // Show a message box to prove we were here
            //VsShellUtilities.ShowMessageBox(
            //    this.package,
            //    message,
            //    title,
            //    OLEMSGICON.OLEMSGICON_INFO,
            //    OLEMSGBUTTON.OLEMSGBUTTON_OK,
            //    OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);
        }


    }
}
