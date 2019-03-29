using System;
using System.Collections.Generic;
using System.Composition;
using System.Text;
using Ultramarine.Generators.Tasks.Library.Contracts;
using Ultramarine.Workspaces;

namespace Ultramarine.Generators.Tasks
{
    [Export(typeof(Task))]
    public class LoadProjectItem : Task
    {
        public string ProjectName { get; set; }
        public string ItemName { get; set; }
        public string LinkedWith { get; set; }

        protected override object OnExecute()
        {
            var project = ExecutionContext.GetProject(ProjectName);
            if (project == null)
                throw new ArgumentException($"There is no project named {ProjectName}");

            var item = project.FindProjectItem(ItemName);
            if (item == null)
                throw new ArgumentException($"There is no project item named {ItemName} in project {ProjectName}");
            return item;
        }
    }
}
