using EnvDTE;
using System;
using System.Collections.Generic;
using Ultramarine.QueryLanguage;

namespace Ultramarine.Workspaces.VisualStudio
{
    public partial class Dte
    {
        private const string _thisAlias = "$this";
        /// <summary>
        /// Gets all the projects which satisfy given expression
        /// </summary>
        /// <param name="projectNameExpression">Expression given in the QueryLanguage form</param>
        /// <returns>List of Visual Studio projects</returns>
        public List<Project> GetProjects(string projectNameExpression)
        {
            var result = new List<Project>();
            var projects = GetProjects();
            foreach(var project in projects)
            {
                var projectName = project.Name;
                var expression = projectNameExpression.Replace("$this", projectName);
                var condition = new ConditionCompiler(expression);
                if ((bool)condition.Execute())
                    result.Add(project);
            }
            return result;
        }

        /// <summary>
        /// Gets all project which satisfy comparer
        /// </summary>
        /// <param name="comparer"></param>
        /// <returns></returns>
        [Obsolete("Comparer is going to be removed in the future. Use expression parser overload.")]
        public List<Project> GetProjects(Comparer comparer)
        {
            var result = new List<Project>();
            var projects = GetProjects();
            foreach (var project in projects)
            {
                var projectProperty = project.Name;
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
