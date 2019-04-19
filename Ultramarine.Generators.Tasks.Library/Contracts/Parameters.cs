using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Ultramarine.Generators.Tasks.Library.Contracts
{
    public class Parameters : Dictionary<string, string>
    {
        private const string GlobalVariableNameExpression = @"(\{(\w+)\})";
        private const string LocalVariableNameExpression = @"(\$\{(\w+)\})";

        public Dictionary<string, string> Prepare()
        {
            Validate(this);
            return this.Select(item =>
                new KeyValuePair<string, string>(item.Key, GetVariableValue(item.Value).ToString()))
            .ToDictionary(k => k.Key, v => v.Value);
        }

        private static void Validate(Dictionary<string, string> parameters)
        {
            if (parameters == null)
                return;

            foreach (var taskParameter in parameters)
            {
                if (string.IsNullOrWhiteSpace(taskParameter.Key) || taskParameter.Value == null)
                    throw new ArgumentNullException(taskParameter.Key, "Invalid parameter attribute value specified");
            }

        }

        private static object GetVariableValue(string variableName)
        {
            return GlobalRegistrar.Variables == null ? null : PrepareVariable(variableName);
        }

        private static string PrepareVariable(string variableName)
        {
            string compositeVariableName = variableName;
            var variables = GetGlobalVariables(variableName);
            foreach (var variable in variables)
            {
                var globalVariable = GlobalRegistrar.Variables.FirstOrDefault(v => v.Name == StripVariableName(variable));
                if (globalVariable == null)
                    throw new ArgumentNullException(variableName, "Referenced global variable was not set!");

                compositeVariableName = compositeVariableName.Replace(variable, globalVariable.Value.ToString());
            }

            return compositeVariableName;

        }

        private static List<string> GetVariables(string variableName, string variableExpression)
        {
            var matches = Regex.Matches(variableName, variableExpression);
            return (from object match in matches select match.ToString()).ToList();
        }

        public static List<string> GetGlobalVariables(string variableName)
        {
            return GetVariables(variableName, GlobalVariableNameExpression);
        }

        private static string StripVariableName(string variableName)
        {
            return variableName.Split('{', '}')[1];
        }

    }
}
