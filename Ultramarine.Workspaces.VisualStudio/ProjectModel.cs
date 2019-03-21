using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.IO;

namespace Ultramarine.Workspaces.VisualStudio
{
    public class ProjectModel : IProjectModel
    {
        private readonly Project _project;
        public ProjectModel(Project project)
        {
            FilePath = project.FilePath;
            Name = project.Name;
            Language = project.Language;
            _project = project;
            ProjectItems = new List<IProjectItemModel>();
        }
        public string FilePath { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
        public List<IProjectItemModel> ProjectItems { get; set; }

        public IProjectItemModel CreateDirectory(string folderPath)
        {
            var document = _project.AddDocument(string.Empty, string.Empty, Directory.GetDirectories(folderPath));
            //TODO: testing purposes only
            return new ProjectItemModel();
        }
    }

    public class ProjectItemModel : IProjectItemModel
    {
        public string FilePath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Language { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<IProjectItemModel> ProjectItems { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }

}
