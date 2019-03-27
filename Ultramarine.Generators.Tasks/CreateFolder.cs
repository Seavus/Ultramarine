using System;
using System.Composition;
using System.IO;
using Ultramarine.Generators.Tasks.Library.Contracts;

namespace Ultramarine.Generators.Tasks
{
    [Export(typeof(Task))]
    public class CreateFolder : Task
    {
        public string FolderPath { get; set; }
        public DirectoryInfo BasePath => Directory.GetParent(ExecutionContext.FilePath);
        protected override object OnExecute()
        {
            return ExecutionContext.CreateDirectory(FolderPath);
        }
    }
}
