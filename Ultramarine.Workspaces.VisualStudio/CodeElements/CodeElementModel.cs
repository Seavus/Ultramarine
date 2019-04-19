using EnvDTE;
using System;
using Ultramarine.Workspaces.CodeElements;

namespace Ultramarine.Workspaces.VisualStudio.CodeElements
{
    [Serializable]
    public class CodeElementModel : ICodeElementModel
    {
        public CodeElementModel(CodeElement codeElement)
        {
            Name = codeElement.Name;
            Type = Convert(codeElement.Kind);
            Access = Convert(codeElement.GetAccess());
            _codeElement = codeElement;
        }

        public string Name { get; set; }
        public ElementType? Type { get; set; }
        public ElementAccess? Access { get; set; }
        public ElementOverride Override { get; set; }

        private CodeElement _codeElement;

        private ElementType? Convert(vsCMElement? elementType)
        {
            if(elementType.HasValue)
            return (ElementType)elementType;
            return null;
        }

        private ElementAccess? Convert(vsCMAccess? elementAccess)
        {
            if (elementAccess.HasValue)
                return (ElementAccess)elementAccess;
            return null;
        }
    }
}
