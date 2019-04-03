using System.Collections.Generic;

namespace Ultramarine.Workspaces
{
    public interface IProjectItemModel
    {
        string FilePath { get; set; }
        string Name { get; set; }
        string Language { get; set; }

        List<IProjectItemModel> ProjectItems { get; set; }

        List<IProjectItemModel> FindProjectItems(string itemNameExpression);

    }
}
