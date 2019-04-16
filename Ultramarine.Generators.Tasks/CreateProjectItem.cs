using System.Composition;
using System.IO;
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
            var projectItemPath = string.IsNullOrWhiteSpace(ProjectName) ? ExecutionContext.FilePath : ProjectName;
            var folderPath = FolderPath ?? string.Empty;
            projectItemPath = Path.Combine(projectItemPath, folderPath, ItemName);

            return ExecutionContext.CreateProjectItem(projectItemPath, Input as string, Overwrite);
        }
    }
}
