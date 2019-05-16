using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;
using Ultramarine.Generators.Tasks.Library.Contracts;
using Ultramarine.Workspaces;

namespace Ultramarine.Generators.Tasks
{
    /// <summary>
    /// Loads a project item
    /// </summary>
    [Export(typeof(Task))]
    public class LoadProjectItem : Task
    {
        private string _projectName;
        private string _itemName;
        private string _linkedWith;

        /// <summary>
        /// Name of the Project to load from
        /// <para>This property supports Variables and QueryLanguage Conditions</para>
        /// </summary>
        public string ProjectName { get => TryGetSettingValue(_projectName) as string; set => _projectName = value; }
        /// <summary>
        /// Name of the Project Item to load
        /// <para>This property supports Variables and QueryLanguage Conditions</para>
        /// </summary>
        public string ItemName { get => TryGetSettingValue(_itemName) as string; set => _itemName = value; }
        /// <summary>
        /// Name of the Project Item that the Item to load is linked with or dependant upon
        /// </summary>
        public string LinkedWith { get => TryGetSettingValue(_linkedWith) as string; set => _linkedWith = value; }

        protected override object OnExecute()
        {
            var result = new List<IProjectItemModel>();
            var projects = string.IsNullOrWhiteSpace(ProjectName) ? new List<IProjectModel> { ExecutionContext } : ExecutionContext.GetProjects(ProjectName);
            if (projects == null || !projects.Any())
                throw new ArgumentException($"There is no project named {ProjectName}");

            foreach (var project in projects)
            {
                var items = string.IsNullOrWhiteSpace(LinkedWith)
                    ? project.GetProjectItems(ItemName)
                    : project.GetProjectItems(ItemName, LinkedWith);
                result.AddRange(items);
            }

            if (!result.Any())
                throw new ArgumentException($"There is no project item named {ItemName} in project {ProjectName}");
            return result;
        }
    }
}
