using EnvDTE;
using EnvDTE80;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Ultramarine.Workspaces.CodeElements;

namespace Ultramarine.Workspaces.VisualStudio.CodeElements
{
    [Serializable]
    public class CodeElementModel : ICodeElementModel
    {
        public CodeElementModel(CodeElement codeElement)
        {
            _codeElement = codeElement;
            Name = codeElement.Name;
            Type = Convert(codeElement.Kind);
            Access = Convert(codeElement.GetAccess());
            TypeOf = GetTypeOf();
            Children = MapCodeElements(codeElement.Children);
            Attributes = GetCustomAttributes();
        }

        public string Name { get; set; }
        public ElementType? Type { get; set; }
        public ElementAccess? Access { get; set; }
        public ElementOverride Override { get; set; }
        public List<string> TypeOf { get; set; }
        public List<ICodeElementModel> Children { get; set; }
        public List<ICodeElementModel> Attributes { get; }

        private CodeElement _codeElement;

        private static ElementType? Convert(vsCMElement? elementType)
        {
            if(elementType.HasValue)
            return (ElementType)elementType;
            return null;
        }

        private static ElementAccess? Convert(vsCMAccess? elementAccess)
        {
            if (elementAccess.HasValue)
                return (ElementAccess)elementAccess;
            return null;
        }

        private List<ICodeElementModel> MapCodeElements(EnvDTE.CodeElements codeElements)
        {
            var result = new List<ICodeElementModel>();
            if (codeElements == null)
                return result;

            for (int i = 1; i < codeElements.Count; i++)
            {
                result.Add(new CodeElementModel(codeElements.Item(i)));
            }
            return result;
        }

        private List<string> GetTypeOf()
        {
            if(Type == ElementType.Class)
            {
                var codeClass = _codeElement as CodeClass2;
                if (codeClass == null)
                    return null;
                var result = new List<string>();
                foreach(var baseClass in codeClass.Bases)
                {
                    var baseClassElement = baseClass as CodeElement;
                    result.Add(baseClassElement.FullName);
                }
                foreach(var baseInterface in codeClass.ImplementedInterfaces)
                {
                    var baseInterfaceElement = baseInterface as CodeElement;
                    result.Add(baseInterfaceElement.FullName);
                }
                return result;
            }
            var codeProperty = _codeElement as CodeProperty2;
            if (codeProperty == null)
                return null;
            return new List<string>() { codeProperty.Type.AsFullName };
        }

        private List<ICodeElementModel> GetCustomAttributes()
        {
            var result = new List<ICodeElementModel>();
            if (_codeElement is CodeClass2)
            {
                foreach (CodeElement attribute in ((CodeClass2)_codeElement).Attributes)
                {
                    result.Add(new CodeElementModel(attribute));
                }
                return result;
            }

            if (_codeElement is CodeProperty2)
            {
                foreach (CodeElement attribute in ((CodeProperty2)_codeElement).Attributes)
                    result.Add(new CodeElementModel(attribute));

                return result;
            }

            return result;
        }
    }
}
