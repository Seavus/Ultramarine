using System;
using System.Composition;
using Ultramarine.Generators.Tasks.Library.Contracts;

namespace Ultramarine.Generators.Tasks
{
    [Export(typeof(Task))]
    public class CreateFolder : Task
    {
        public string BasePath { get; set; }
        public string FolderPath { get; set; }
        protected override object Run()
        {
            throw new NotImplementedException();
        }
    }
}
