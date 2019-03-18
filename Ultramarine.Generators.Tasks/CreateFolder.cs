using System;
using System.ComponentModel.Composition;
using Ultramarine.Generators.Tasks.Library.Contracts;

namespace Ultramarine.Generators.Tasks
{
    [Export(typeof(Task))]
    public class CreateFolder : Task
    {
        public string FolderName { get; set; }
        protected override object Run()
        {
            throw new NotImplementedException();
        }
    }
}
