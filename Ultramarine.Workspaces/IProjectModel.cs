using System.Collections.Generic;
using System.IO;

namespace Ultramarine.Workspaces
{
    public interface IProjectModel
    {
        string FilePath { get; set; }
        string Name { get; set; }
        string Language { get; set; }

        List<IProjectItemModel> ProjectItems { get; set; }

        IProjectItemModel CreateDirectory(string folderPath);

        IProjectItemModel CreateProjectItem(string path, string content, bool overwrite);
        IProjectItemModel CreateProjectItem(string path, MemoryStream content, bool overwrite);
        IProjectItemModel CreateProjectItem(string path, byte[] content, bool overwrite);
        IProjectItemModel CreateProjectItem(string path, object content, bool overwrite);
        IEnumerable<IProjectModel> GetProjects(string expression);
        IProjectItemModel GetProjectItem(string path);
        IEnumerable<IProjectItemModel> GetProjectItems(string expression, string propertyName = "Name");
        IEnumerable<IProjectItemModel> GetProjectItems(string expression, string dependentUpon, string propertyName = "Name");
        string ProcessTextTemplate(string t4File, object input, Dictionary<string, object> parameters);
        IWorkspaceModel GetWorkspace();
        bool Build(string configuration);
    }
}
