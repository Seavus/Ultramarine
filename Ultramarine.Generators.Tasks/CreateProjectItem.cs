using System.Composition;
using System.IO;
using System.Linq;
using Ultramarine.Generators.Tasks.Library.Contracts;

namespace Ultramarine.Generators.Tasks
{
    [Export(typeof(Task))]
    public class CreateProjectItem : Task
    {
        public string ItemName { get; set; }
        public string FolderPath { get; set; }
        public string LinkedWith { get; set; }
        public string ProjectName { get; set; }
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
            return project.CreateProjectItem(projectItemPath, Input, Overwrite);
        }
    }
}
