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
        IProjectItemModel CreateProjectItem(string path, object content, bool overwrite);
        IEnumerable<IProjectModel> GetProjects(string expression);
        IEnumerable<IProjectItemModel> GetProjectItems(string expression);
        IEnumerable<IProjectItemModel> GetProjectItems(string expression, string dependentUpon);
        string ProcessTextTemplate(string t4File, object input, Dictionary<string, string> parameters);
        
        bool Build(string configuration);
    }
}
