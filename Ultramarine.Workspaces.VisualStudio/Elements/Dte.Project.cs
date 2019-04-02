using EnvDTE;
using System.Collections.Generic;

namespace Ultramarine.Workspaces.VisualStudio
{
    public partial class Dte
    {
        
        public List<Project> GetProjects(Comparer comparer)
        {
            var result = new List<Project>();
            var projects = GetProjects();
            foreach (var project in projects)
            {
                var projectProperty = project.Properties.Item("Name").Value.ToString();
                var checkResult = comparer.Check(projectProperty);
                if (checkResult)
                    result.Add(project);                
            }

            return result;
        }

        /// <summary>
        /// Gets all of the projects in currently loaded solution
        /// </summary>
        /// <returns>List of all of the projects in solution</returns>
        public List<Project> GetProjects()
        {
            return GetProjects(Host.Solution);
        }

        /// <summary>
        /// Gets all of the projects in a solution
        /// </summary>
        /// <param name="solution">Solution to scan</param>
        /// <returns>List of all of the projects in solution</returns>
        public List<Project> GetProjects(Solution solution)
        {
            var result = new List<Project>();
            for(var i = 1; i<= solution.Projects.Count; i++)
            {
                var project = solution.Projects.Item(i);
                if(project.Kind == Constants.vsProjectKindSolutionItems)
                {
                    var solutionFolderProjects = GetProjects(project);
                    result.AddRange(solutionFolderProjects);
                }
                result.Add(project);
            }

            return result;
        }

        /// <summary>
        /// Gets all of the projects in a solution folder
        /// </summary>
        /// <param name="solutionFolder">Solution folder to scan</param>
        /// <returns>List of the projects in a solution folder</returns>
        public List<Project> GetProjects(Project solutionFolder)
        {
            var result = new List<Project>();
            for (var i = 1; i <= solutionFolder.ProjectItems.Count; i++)
            {
                var subProject = solutionFolder.ProjectItems.Item(i).SubProject;
                if (subProject == null)
                    continue;

                // subProject is another solution folder, go deep
                if (subProject.Kind == Constants.vsProjectKindSolutionItems)
                {
                    var projects = GetProjects(solutionFolder);
                    result.AddRange(projects);
                }
                else
                    result.Add(subProject);

            }
            return result;
        }
    }
}
