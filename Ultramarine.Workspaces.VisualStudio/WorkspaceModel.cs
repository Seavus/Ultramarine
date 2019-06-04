using EnvDTE;
using System.Collections.Generic;
using System.Linq;

namespace Ultramarine.Workspaces.VisualStudio
{
    public class WorkspaceModel: IWorkspaceModel
    {
        private Solution _solution;

        public WorkspaceModel(Solution solution)
        {
            _solution = solution;
        }

        public IProjectItemModel GetProjectItem(string path)
        {
            var results = new List<ProjectItem>();
            foreach (Project project in _solution.Projects)
            {
                var projectItems = GetProjectItems(project.ProjectItems, "FullPath", path);
                results.AddRange(projectItems);

            }

            if (!results.Any())
                return null;

            return new ProjectItemModel(results.First());
        }

        private List<ProjectItem> GetProjectItems(ProjectItems items, string propertyName, string val)
        {
            var result = new List<ProjectItem>();
            foreach(ProjectItem projectItem in items)
            {
                var propertyValue = GetProperty(projectItem, propertyName);
                if (propertyValue == val)
                    result.Add(projectItem);
            }

            return result;
        }

        private string GetProperty(ProjectItem item, string propertyName)
        {
            try
            {
                return item.Properties.Item(propertyName).Value.ToString();
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
