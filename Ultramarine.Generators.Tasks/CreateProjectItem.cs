using System.Composition;
using System.IO;
using System.Linq;
using Ultramarine.Generators.Tasks.Library.Contracts;

namespace Ultramarine.Generators.Tasks
{
    /// <summary>
    /// Creates a project item
    /// </summary>
    [Export(typeof(Task))]
    public class CreateProjectItem : Task
    {
        private string _itemName;
        private string _folderPath;
        private string _linkedWith;
        private string _projectName;

        /// <summary>
        /// Name of the item to create
        /// <para>This property supports Variables</para>
        /// </summary>
        public string ItemName { get => TryGetSettingValue(_itemName) as string; set => _itemName = value; }
        
        /// <summary>
        /// Folde path of the item to create
        /// <para>This property supports Variables</para>
        /// </summary>
        public string FolderPath { get => TryGetSettingValue(_folderPath) as string; set => _folderPath = value; }
        
        /// <summary>
        /// Name of the project item to link this item to
        /// <para>This property supports Variables</para>
        /// </summary>
        public string LinkedWith { get => TryGetSettingValue(_linkedWith) as string; set => _linkedWith = value; }
        
        /// <summary>
        /// Name of the project in which the item will be created
        /// <para>This property supports Variables and QueryLanguage Condition</para>
        /// </summary>
        public string ProjectName { get => TryGetSettingValue(_projectName) as string; set => _projectName = value; }
        
        /// <summary>
        /// Should this project item overwrite the existing project item(s)
        /// </summary>
        public bool Overwrite { get; set; }

        protected override object OnExecute()
        {
            var project = string.IsNullOrWhiteSpace(ProjectName)
                ? ExecutionContext
                : ExecutionContext.GetProjects($"$this equals '{ProjectName}'").FirstOrDefault();

            var folderPath = FolderPath ?? string.Empty;
            var projectItemPath = Path.Combine(project.FilePath, folderPath, ItemName);
            if (Input is string)
                return project.CreateProjectItem(projectItemPath, Input as string, Overwrite);
            if (Input is MemoryStream)
                return project.CreateProjectItem(projectItemPath, Input as MemoryStream, Overwrite);
            if (Input is byte[])
                return project.CreateProjectItem(projectItemPath, Input as byte[], Overwrite);
            return project.CreateProjectItem(projectItemPath, Input, Overwrite);
        }
    }
}
