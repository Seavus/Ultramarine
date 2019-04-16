using EnvDTE;
using EnvDTE80;
using System.Collections.Generic;
using System.Linq;
using Ultramarine.QueryLanguage;
using Ultramarine.Workspaces.CodeElements;
using Ultramarine.Workspaces.VisualStudio.CodeElements;

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

        public List<IProjectItemModel> GetProjectItems(string expression)
        {
            var result = new List<IProjectItemModel>();
            var condition = new ConditionCompiler(expression, Name);
            if (condition.Execute())
                result.Add(this);

            foreach (var item in ProjectItems)
            {
                var subItems = item.GetProjectItems(expression);
                if (subItems != null)
                    result.AddRange(subItems);
            }
            return result;
        }

        public List<ICodeElementModel> GetCodeElements(string expression)
        {
            var result = new List<CodeElement>();
            foreach (CodeElement codeElement in _projectItem.FileCodeModel.CodeElements)
            {
                if (codeElement.IsCodeType)
                {
                    var condition = new ConditionCompiler(expression, codeElement.Name);
                    if (condition.Execute())
                        result.Add(codeElement);
                    else
                        result.AddRange(GetInnerCodeElements(codeElement, expression));
                }
                else
                {
                    result.AddRange(GetInnerCodeElements(codeElement, expression));
                }
            }
            return result.Select<CodeElement, ICodeElementModel>(c => new CodeElementModel(c)).ToList();
        }

        public List<CodeElement> GetInnerCodeElements(CodeElement codeElement, string expression)
        {
            var results = new List<CodeElement>();

            switch (codeElement.Kind)
            {
                case vsCMElement.vsCMElementNamespace:
                case vsCMElement.vsCMElementStruct:
                case vsCMElement.vsCMElementClass:
                case vsCMElement.vsCMElementInterface:
                    {
                        var codeElements = GetCodeElements(codeElement, expression);
                        results.AddRange(codeElements);
                        break;
                    }
            }

            return results;
        }

        private List<CodeElement> GetCodeElements(CodeElement codeElement, string expression)
        {
            var result = new List<CodeElement>();
            var elements = new List<CodeElement>();

            switch (codeElement.Kind)
            {
                case vsCMElement.vsCMElementInterface:
                    {
                        var codeInterface = codeElement as CodeInterface2;
                        elements.AddRange(codeInterface.Parts.Cast<CodeElement>());
                        break;
                    }
                case vsCMElement.vsCMElementClass:
                    {
                        var codeClass = codeElement as CodeClass2;
                        elements.AddRange(codeClass.Parts.Cast<CodeElement>());
                        break;
                    }
                case vsCMElement.vsCMElementStruct:
                    {
                        var codeStruct = codeElement as CodeStruct2;
                        elements.AddRange(codeStruct.Parts.Cast<CodeElement>());
                        break;
                    }
                case vsCMElement.vsCMElementNamespace:
                    {
                        elements.AddRange(new List<CodeElement> { codeElement });
                        break;
                    }
            }
            if (!elements.Any())
                elements.Add(codeElement);

            foreach (var element in elements)
            {
                foreach (CodeElement child in element.Children)
                {
                    var children = GetCodeElements(child, expression);
                    result.AddRange(children);
                    if (child.HasName())
                    {
                        var condition = new ConditionCompiler(expression, child.Name);

                        if (condition.Execute())
                        {
                            result.Add(child);
                            continue;
                        }
                    }

                    result.AddRange(GetInnerCodeElements(child, expression));

                }
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
