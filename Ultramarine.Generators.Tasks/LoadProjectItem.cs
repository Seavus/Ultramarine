using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
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
            var result = new List<IProjectItemModel>();
            var projects = ExecutionContext.GetProjects(ProjectName);
            if (projects == null || !projects.Any())
                throw new ArgumentException($"There is no project named {ProjectName}");

            foreach (var project in projects)
            {
                var items = project.GetProjectItems(ItemName);
                result.AddRange(items);
            }

            if (!result.Any())
                throw new ArgumentException($"There is no project item named {ItemName} in project {ProjectName}");
            return result;
        }
    }
}
