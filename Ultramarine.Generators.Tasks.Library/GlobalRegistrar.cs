using System.Collections.Generic;

namespace Ultramarine.Generators.Tasks.Library
{
    public static class GlobalRegistrar
    {
        public static List<Variable> Variables { get; set; } = new List<Variable>();
        public static void AddVariable(Variable variable)
        {
            var index = Variables.FindIndex(c => c.Name == variable.Name);
            if (index != -1)
                Variables[index] = variable;
            else
                Variables.Add(variable);
        }

    }
}
