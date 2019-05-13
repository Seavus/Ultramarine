using System.Collections.Generic;
using System.Composition;
using Ultramarine.Generators.Tasks.Library.Contracts;
using Ultramarine.Workspaces;

namespace Ultramarine.Generators.Tasks
{
    /// <summary>
    /// Project build task
    /// </summary>
    [Export(typeof(Task))]
    public class BuildProject : Task
    {
        private string _projectName;
        private string _configuration = "Debug";
        /// <summary>
        /// Name of the project to build
        /// <para>This property supports Variables and QueryLanguage Conditions</para>
        /// <c>If left empty, the current execution context is being used (a project containing configuration file)</c>
        /// </summary>
        public string ProjectName { get => TryGetSettingValue(_projectName) as string; set => _projectName = value; }
        /// <summary>
        /// Name of the configuration to build
        /// <para>This property supports Variables</para>
        /// <c>Defaults to Debug</c>
        /// </summary>
        public string Configuration { get => TryGetSettingValue(_configuration) as string; set => _configuration = value; }

        protected override object OnExecute()
        {
            var result = new Dictionary<string, bool>();
            var projects = string.IsNullOrWhiteSpace(ProjectName)
                ? new List<IProjectModel> { ExecutionContext }
                : ExecutionContext.GetProjects(ProjectName);            
            foreach (var project in projects)
            {
                var buildResult = project.Build(Configuration);
                result.Add(project.Name, buildResult);
            }

            return result;
        }
    }
}
