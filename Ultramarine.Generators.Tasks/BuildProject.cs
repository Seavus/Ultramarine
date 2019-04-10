using System.Collections.Generic;
using System.Composition;
using Ultramarine.Generators.Tasks.Library.Contracts;
using Ultramarine.Workspaces;

namespace Ultramarine.Generators.Tasks
{
    [Export(typeof(Task))]
    public class BuildProject : Task
    {
        public string ProjectName { get; set; }
        public string Configuration { get; set; }

        protected override object OnExecute()
        {
            var result = new Dictionary<string, bool>();
            var projects = string.IsNullOrWhiteSpace(ProjectName)
                ? new List<IProjectModel> { ExecutionContext }
                : ExecutionContext.GetProjects(ProjectName);
            foreach(var project in projects)
            {
                var buildResult = project.Build(Configuration);
                result.Add(project.Name, buildResult);
            }

            return result;
        }
    }
}
