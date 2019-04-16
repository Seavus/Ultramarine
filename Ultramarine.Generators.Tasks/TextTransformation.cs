using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using Ultramarine.Generators.Tasks.Library.Contracts;
using Ultramarine.Workspaces;

namespace Ultramarine.Generators.Tasks
{
    [Export(typeof(Task))]
    public class TextTransformation : Task
    {
        public Parameters Parameters { get; set; } = new Parameters();
        public string FileName { get; set; }
        public string ProjectName { get; set; }

        protected override object OnExecute()
        {
            var t4Template = GetT4FilePath();
            var result = ExecutionContext.ProcessTextTemplate(t4Template, Input, Parameters.Prepare());
            return result;
        }

        private string GetT4FilePath()
        {
            var projects = string.IsNullOrEmpty(ProjectName) 
                ? new List<IProjectModel> { ExecutionContext } 
                : ExecutionContext.GetProjects(ProjectName);

            var templateItems = new List<IProjectItemModel>();
            foreach (var project in projects)
            {
                var items = project.GetProjectItems(FileName);
                templateItems.AddRange(items);
            }

            if (!templateItems.Any())
                throw new ArgumentException($"There is no project item named {FileName} in project {ProjectName}");

            var t4Template = templateItems.First();
            return t4Template.FilePath;
        }
    }
}
