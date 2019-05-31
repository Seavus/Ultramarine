using EnvDTE;
using System;

namespace Ultramarine.Workspaces.VisualStudio.CodeElements
{
    public static class CodeElementExtensions
    {
        public static bool HasName(this CodeElement element)
        {
            try
            {
                var elementName = element.Name;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static vsCMAccess GetAccess(this CodeElement element)
        {
            if (element is CodeClass)
                return ((CodeClass)element).Access;

            if (element is CodeInterface)
                return ((CodeInterface)element).Access;

            if (element is CodeFunction)
                return ((CodeFunction)element).Access;

            if (element is CodeProperty)
                return ((CodeProperty)element).Access;

            //if(element is CodeAttribute)
            //    return vsCMAccess.vsCMAccessPrivate;
            return vsCMAccess.vsCMAccessPrivate;

            throw new Exception("Failed to check code element access. Unsuppported code element.");
        }


    }
}
