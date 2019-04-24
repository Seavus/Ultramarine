using EnvDTE;
using EnvDTE80;
using System;
using System.Collections.Generic;
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
        }

        public string Name { get; set; }
        public ElementType? Type { get; set; }
        public ElementAccess? Access { get; set; }
        public ElementOverride Override { get; set; }
        public List<string> TypeOf { get; set; }

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
    }
}
