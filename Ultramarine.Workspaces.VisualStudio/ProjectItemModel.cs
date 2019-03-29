using EnvDTE;
using System.Collections.Generic;

namespace Ultramarine.Workspaces.VisualStudio
{
    public class ProjectItemModel : IProjectItemModel
    {
        private ProjectItem _projectItem;
        public ProjectItemModel(ProjectItem projectItem)
        {
            Name = projectItem.Name;
            FilePath = projectItem.Properties.Item("FullPath").Value.ToString();
            Language = projectItem.FileCodeModel == null ? null : projectItem.FileCodeModel.Language;
            ProjectItems = MapProjectItems(projectItem.ProjectItems);

            _projectItem = projectItem;
        }
        public string FilePath { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
        public List<IProjectItemModel> ProjectItems { get; set; }

        public IProjectItemModel FindProjectItem(string itemName)
        {
            if (Name == itemName)
                return this;
            foreach (var item in ProjectItems)
            {
                if (item.Name == itemName)
                    return item;
                var subItem = item.FindProjectItem(itemName);
                if (subItem != null)
                    return subItem;
            }
            return null;
        }
        private List<IProjectItemModel> MapProjectItems(ProjectItems projectItems)
        {
            var result = new List<IProjectItemModel>();

            for (int i = 1; i < projectItems.Count; i++)
            {
                result.Add(new ProjectItemModel(projectItems.Item(i)));
            }

            return result;
        }
    }

}
