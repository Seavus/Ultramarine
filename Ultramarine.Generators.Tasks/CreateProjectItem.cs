using System.Composition;
using System.IO;
using System.Linq;
using Ultramarine.Generators.Tasks.Library.Contracts;

namespace Ultramarine.Generators.Tasks
{
    [Export(typeof(Task))]
    public class CreateProjectItem : Task
    {
        private string _itemName;
        private string _folderPath;
        private string _linkedWith;
        private string _projectName;

        public string ItemName { get => TryGetSettingValue(_itemName) as string; set => _itemName = value; }
        public string FolderPath { get => TryGetSettingValue(_folderPath) as string; set => _folderPath = value; }
        public string LinkedWith { get => TryGetSettingValue(_linkedWith) as string; set => _linkedWith = value; }
        public string ProjectName { get => TryGetSettingValue(_projectName) as string; set => _projectName = value; }
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
