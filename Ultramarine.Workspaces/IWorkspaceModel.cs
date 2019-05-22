using System;

namespace Ultramarine.Workspaces
{
    public interface IWorkspaceModel
    {
        IProjectItemModel GetProjectItem(string path);
    }
}
