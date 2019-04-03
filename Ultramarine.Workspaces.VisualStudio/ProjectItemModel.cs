using EnvDTE;
using System.Collections.Generic;
using Ultramarine.QueryLanguage;

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

        public List<IProjectItemModel> FindProjectItems(string itemNameExpression)
        {
            var result = new List<IProjectItemModel>();
            var expression = itemNameExpression.Replace("${this}", Name);
            var condition = new ConditionCompiler(expression);
            if ((bool)condition.Execute())
                result.Add(this);

            foreach(var item in ProjectItems)
            {
                var subItems = item.FindProjectItems(itemNameExpression);
                if (subItems != null)
                    result.AddRange(subItems);
            }
            return result;
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
