using System.Composition;
using System.IO;
using Ultramarine.Generators.Tasks.Library.Contracts;

namespace Ultramarine.Generators.Tasks
{
    /// <summary>
    /// Creates a folder on a specified location
    /// </summary>
    [Export(typeof(Task))]
    public class CreateFolder : Task
    {
        private string _folderPath;
        private string _basePath;

        /// <summary>
        /// Folder path to create
        /// <para>This property supports Variables</para>
        /// </summary>
        public string FolderPath { get => TryGetSettingValue(_folderPath) as string; set => _folderPath = value; }
        /// <summary>
        /// Base path of the folder to create
        /// <para>This property supports Variables</para>
        /// </summary>
        public string BasePath { get => TryGetSettingValue(_basePath) as string; set => _basePath = value; }

        protected override object OnExecute()
        {
            if(string.IsNullOrWhiteSpace(BasePath))
            return ExecutionContext.CreateDirectory(FolderPath);

            var directory = new DirectoryInfo(Path.Combine(BasePath, FolderPath));
            directory.Create();
            return directory.ToString();
        }

        protected override ValidationResult Validate()
        {
            if (string.IsNullOrWhiteSpace(FolderPath))
                return new ValidationResult(nameof(FolderPath), "FolderPath must be specified.");
            return base.Validate();
        }
    }
}
