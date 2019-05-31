using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;
using Ultramarine.Generators.Serialization.Providers;
using Ultramarine.Generators.Tasks.Library.Contracts;

namespace Ultramarine.Generators.Tasks.Complex
{
    [Export(typeof(Task))]
    public class Importer : Task
    {
        private string _path;
        private string _projectName;
        public string Path { get => TryGetSettingValue(_path) as string; set => _path = value; }
        public string ProjectName { get => TryGetSettingValue(_projectName) as string; set => _projectName = value; }

        protected override object OnExecute()
        {
            var generatorPath = GetGeneratorPath();

            var generatorProjectItem = ExecutionContext.GetWorkspace().GetProjectItem(generatorPath);
            var context = generatorProjectItem == null ? ExecutionContext : generatorProjectItem.Project;

            var generator = GeneratorSerializer.Instance.Load(generatorPath);
            generator.SetExecutionContext(context);
            generator.SetLogger(Logger);

            generator.Input = Input;
            generator.Execute();

            return generator.Output;
        }

        protected override ValidationResult Validate()
        {
            if (string.IsNullOrWhiteSpace(Path))
                return new ValidationResult(nameof(Path), "Path must be specified.");

            return base.Validate();
        }

        private string GetGeneratorPath()
        {
            var project = string.IsNullOrWhiteSpace(ProjectName)
               ? ExecutionContext
               : ExecutionContext.GetProjects(ProjectName).FirstOrDefault();

            if (project == null)
                throw new ArgumentException("Specified project name doesn't exist.", nameof(ProjectName));

            var generatorPath = System.IO.Path.Combine(project.FilePath, Path);

            return generatorPath;
        }

    }
}
