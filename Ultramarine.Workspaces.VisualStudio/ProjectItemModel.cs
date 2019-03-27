using EnvDTE;
using System;
using System.Collections.Generic;

namespace Ultramarine.Workspaces.VisualStudio
{
    public class ProjectItemModel : IProjectItemModel
    {
        public ProjectItemModel(ProjectItem projectItem)
        {

        }
        public string FilePath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Language { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<IProjectItemModel> ProjectItems { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }

}
