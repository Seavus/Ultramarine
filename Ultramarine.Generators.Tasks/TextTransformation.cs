using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Xml.Serialization;
using Ultramarine.Generators.Tasks.Library.Contracts;
using Ultramarine.Workspaces;

namespace Ultramarine.Generators.Tasks
{
    /// <summary>
    /// Applies a text transformation template
    /// </summary>
    [Export(typeof(Task))]
    public class TextTransformation : Task
    {
        private string _fileName;
        private string _projectName;

        /// <summary>
        /// Additional parameters to send to the generation process
        /// </summary>
        [XmlIgnore]
        public Parameters Parameters { get; set; } = new Parameters();
        /// <summary>
        /// T4 file name to use
        /// <para>This property supports Variables and QueryLanguage Conditions</para>
        /// </summary>
        public string FileName { get => TryGetSettingValue(_fileName) as string; set => _fileName = value; }
        /// <summary>
        /// Name of the Project containing the T4 file
        /// <para>This property supports Variables and QueryLanguage Conditions</para>
        /// </summary>
        public string ProjectName { get => TryGetSettingValue(_projectName) as string; set => _projectName = value; }

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
