using System.Collections.Generic;
using Ultramarine.Workspaces.CodeElements;

namespace Ultramarine.Workspaces
{
    public interface IProjectItemModel
    {
        string FilePath { get; set; }
        string Name { get; set; }
        string Language { get; set; }
        List<IProjectItemModel> ProjectItems { get; set; }
        List<IProjectItemModel> GetProjectItems(string expression);
        List<ICodeElementModel> GetCodeElements(string expression);
    }
}
