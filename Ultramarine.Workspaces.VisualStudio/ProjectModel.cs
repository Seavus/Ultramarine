using EnvDTE;
using Microsoft.VisualStudio.TextTemplating;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Ultramarine.QueryLanguage;
using Ultramarine.QueryLanguage.Comparers;
using Ultramarine.Workspaces.VisualStudio.T4;

namespace Ultramarine.Workspaces.VisualStudio
{
    public class ProjectModel : IProjectModel
    {
        private readonly Project _project;
        public ProjectModel(Project project)
        {
            FilePath = project.Properties.Item("FullPath").Value.ToString();
            Name = project.Name;
            Language = project.CodeModel == null ? null : project.CodeModel.Language;
            ProjectItems = MapProjectItems(project.ProjectItems);
            _project = project;
        }

        public ProjectModel(string projectName) : this(Dte.Instance.GetProject(projectName))
        {

        }

        public string FilePath { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
        public List<IProjectItemModel> ProjectItems { get; set; }

        public bool Build(string configuration)
        {
            try
            {
                Dte.Instance.Host.Solution.SolutionBuild.BuildProject(configuration, _project.UniqueName, true);
                return true;
            }
            catch (Exception ex)
            {
                //todo: log exception
                return false;
            }
        }

        public IProjectItemModel CreateDirectory(string folderPath)
        {
            var dirs = folderPath.Split(Path.DirectorySeparatorChar).ToList();
            var firstDir = dirs.FirstOrDefault();
            var projectItem = EnsureDirectoryExists(_project.ProjectItems, firstDir);
            dirs.Remove(firstDir);
            foreach (var dir in dirs)
            {
                projectItem = EnsureDirectoryExists(projectItem.ProjectItems, dir);
            }
            return new ProjectItemModel(projectItem);
        }

        public IProjectItemModel CreateProjectItem(string path, string content, bool overwrite)
        {
            if (!overwrite)
                if (File.Exists(path))
                    throw new Exception(string.Format("Failed to create project item. File '{0}' already exist on file system.", path));

            var directoryPath = Path.GetDirectoryName(path);
            Directory.CreateDirectory(directoryPath);
            File.WriteAllText(path, content);
            var projectItem = _project.ProjectItems.AddFromFile(path);

            return new ProjectItemModel(projectItem);
        }

        public IProjectItemModel CreateProjectItem(string path, MemoryStream content, bool overwrite)
        {
            if (!overwrite)
                if (File.Exists(path))
                    throw new Exception($"Failed to create project item. File '{path}' already exists on file system.");
            var directoryPath = Path.GetDirectoryName(path);
            Directory.CreateDirectory(directoryPath);
            using(var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                byte[] bytes = new byte[content.Length];
                content.Read(bytes, 0, (int)content.Length);
                fs.Write(bytes, 0, bytes.Length);
                content.Close();
            }

            var projectItem = _project.ProjectItems.AddFromFile(path);
            return new ProjectItemModel(projectItem);
        }

        public IProjectItemModel CreateProjectItem(string path, object content, bool overwrite)
        {
            return CreateProjectItem(path, JsonConvert.SerializeObject(content), overwrite);
        }

        public IProjectItemModel CreateProjectItem(string path, byte[] content, bool overwrite)
        {
            var contentStream = new MemoryStream(content);
            return CreateProjectItem(path, contentStream, overwrite);
        }

        public IEnumerable<IProjectModel> GetProjects(string projectNameExpression)
        {
            var projects = Dte.Instance.GetProjects(projectNameExpression);
            return projects.Select(proj => new ProjectModel(proj)).ToList();
        }

        public IProjectModel GetProject(string projectName)
        {
            return new ProjectModel(projectName);
        }

        private ProjectItem EnsureDirectoryExists(ProjectItems projectItems, string folderName)
        {
            ProjectItem projectItem;
            try
            {
                var projectPath = projectItems.ContainingProject.Properties.Item("FullPath").Value.ToString();
                var directoryPath = Path.Combine(projectPath, folderName);
                if (Directory.Exists(directoryPath))
                    projectItem = projectItems.AddFromDirectory(directoryPath);
                else
                    projectItem = projectItems.AddFolder(folderName);

            }
            catch (Exception ex)
            {
                var item = GetProjectItems(projectItems, new Comparer(folderName, OperatorType.Equals)).FirstOrDefault(); //GetProjectItems(projectItems, true, false, new Conditioner(folderName, StringComparisonType.Equal)).FirstOrDefault();
                if (item == null)
                    throw new Exception(string.Format("Unknown exception while trying to find directory {0}", folderName));
                projectItem = item;
            }
            return projectItem;
        }

        
        public IEnumerable<IProjectItemModel> GetProjectItems(string expression, string propertyName = "Name")
        {
            var result = new List<IProjectItemModel>();
            foreach (var item in ProjectItems)
            {
                var condition = new ConditionCompiler(expression, item.GetProperty(propertyName));
                if (condition.Execute())
                    result.Add(item);

                var subItems = item.GetProjectItems(expression);
                if (subItems != null)
                {
                    subItems.Remove(item);
                    result.AddRange(subItems);
                }
            }
            return result;
        }

        public IEnumerable<IProjectItemModel> GetProjectItems(string expression, string dependentUpon, string propertyName = "Name")
        {
            var result = new List<IProjectItemModel>();
            var dependentProjectItems = GetProjectItems($"$this equals {dependentUpon}", propertyName);
            foreach (var dpi in dependentProjectItems)
            {
                var items = dpi.GetProjectItems(expression);
                result.AddRange(result);
            }
            return result;
        }
        private List<ProjectItem> GetProjectItems(ProjectItems projectItems, Comparer comparer, string propertyName = null)
        {
            var result = new List<ProjectItem>();
            if (projectItems == null)
                return result;

            foreach (ProjectItem projectItem in projectItems)
            {
                var propertyValue = string.IsNullOrWhiteSpace(propertyName)
                    ? projectItem.Name
                    : GetPropertyValue(projectItem, propertyName);

                var comparisonResult = comparer.Check(propertyValue);
                if (comparisonResult)
                    result.Add(projectItem);

                var childProjectItems = projectItem.ProjectItems;
                if (childProjectItems == null)
                    continue;

                result.AddRange(GetProjectItems(childProjectItems, comparer, propertyName));
            }
            return result;
        }

        //TODO: refactor
        private string GetPropertyValue(ProjectItem item, string propertyName)
        {
            try
            {
                return item.Properties.Item(propertyName).Value.ToString();
            }
            catch
            {
                return string.Empty;
            }
        }

        private List<IProjectItemModel> MapProjectItems(ProjectItems projectItems)
        {
            var result = new List<IProjectItemModel>();

            for (int i = 1; i <= projectItems.Count; i++)
            {
                result.Add(new ProjectItemModel(projectItems.Item(i)));
            }

            return result;
        }

        public string ProcessTextTemplate(string t4File, object input, Dictionary<string, object> parameters)
        {
            var textTemplating = Dte.Instance.TextTemplating;
            var sessionHost = textTemplating as ITextTemplatingSessionHost;

            if (input == null)
                input = new object();

            sessionHost.Session = sessionHost.CreateSession();
            sessionHost.Session["Input"] = input;
            sessionHost.Session["Parameters"] = parameters;

            var t4FileContent = File.ReadAllText(t4File);
            var logger = new TransformationLogger();

            textTemplating.BeginErrorSession();
            var result = textTemplating.ProcessTemplate(t4File, t4FileContent, logger);
            textTemplating.EndErrorSession();

            if (logger.HasMessages)
            {
                foreach (var transformationError in logger.Errors)
                {
                    var type = transformationError.IsWarning ? "WARNING" : "ERROR";
                    //TODO: logger
                    //Extensions.DteExtensions.Instance.Log(string.Format("{0} in line {1}, column {2}", type, transformationError.Line, transformationError.Column));
                    //Extensions.DteExtensions.Instance.Log(transformationError.Message);
                    //Extensions.DteExtensions.Instance.Log(string.Format("//{0}", type));
                }
            }

            if (logger.HasErrors)
                throw new Exception("Errors executing T4 transformation. See output log for details.");



            return result;
        }

        public IProjectItemModel GetProjectItem(string path)
        {
            return GetProjectItems($"$this equals '{path}'", "FullPath").FirstOrDefault();
        }

        public IWorkspaceModel GetWorkspace()
        {
            return new WorkspaceModel(Dte.Instance.Host.Solution);
        }
        
    }

}
