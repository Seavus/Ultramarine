using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using Ultramarine.Workspaces;

namespace Ultramarine.Generators.Tasks.Library.Contracts
{
    public abstract class Task : ITask
    {
        private const string GlobalVariableNameExpression = @"(\$\{(\w+)\})";
        private const string LocalVariableNameExpression = @"(\{(\w+)\})";

        protected Task() : this(null)
        {

        }
        protected Task(string name)
        {
            Name = name;
            Variables = new List<Variable>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public object Input { get; set; }
        public object Output { get; set; }

        [XmlIgnore]
        public Task Parent { get; set; }
        public string ConnectedWith { get; set; }

        public List<Variable> Variables { get; set; }
        protected virtual ValidationResult Validate()
        {
            var validationResult = new ValidationResult();
            if (string.IsNullOrWhiteSpace(Name))
                validationResult.Add(nameof(Name), "Name must not be empty");

            return validationResult;
        }

        protected abstract object OnExecute();

        public IProjectModel ExecutionContext { get; private set; }

        public ILogger Logger { get; private set; }

        public virtual void SetExecutionContext(IProjectModel executionContext)
        {
            ExecutionContext = executionContext;
        }

        public virtual void SetLogger(ILogger logger)
        {
            Logger = logger;
        }

        public virtual void Execute()
        {
            Logger.Info($"Starting {GetType()} execution: {Name}");

            Validate();
            Output = OnExecute();

            Logger.Info($"Ending {GetType()} execution: {Name}");
        }

        private static bool IsVariable(string variableName, string variableExpression)
        {
            if (string.IsNullOrWhiteSpace(variableName))
                return false;
            return Regex.IsMatch(variableName, variableExpression);
        }

        public static bool IsGlobalVariable(string variableName)
        {
            return IsVariable(variableName, GlobalVariableNameExpression);
        }

        public static bool IsLocalVariable(string variableName)
        {
            return IsVariable(variableName, LocalVariableNameExpression);
        }
        public static object GetGlobalVariableValue(string variableName)
        {
            return GlobalRegistrar.Variables == null ? null : PrepareGlobalVariableName(variableName);
        }

        public static object GetLocalVariableValue(string variableName, Task parentTask)
        {
            return parentTask.Variables == null ? null : PrepareLocalVariableName(variableName, parentTask);
        }

        private static string PrepareGlobalVariableName(string variableName)
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

        public static List<string> GetLocalVariables(string variableName)
        {
            return GetVariables(variableName, LocalVariableNameExpression);
        }

        private static string StripVariableName(string variableName)
        {
            return variableName.Split('{', '}')[1];
        }
        private static string PrepareLocalVariableName(string variableName, Task parentTask)
        {
            string compositeVariableName = variableName;
            var variables = GetLocalVariables(variableName);
            foreach (var variable in variables)
            {
                var localVariable = parentTask.Variables.FirstOrDefault(v => v.Key == StripVariableName(variable));
                if (localVariable == null)
                    throw new ArgumentNullException(variableName, "Referenced local variable was not set!");

                compositeVariableName = compositeVariableName.Replace(variable, localVariable.Value.ToString());
            }

            return compositeVariableName;

        }

        protected object TryGetSettingValue(string setting)
        {
            if (IsGlobalVariable(setting))
                return GetGlobalVariableValue(setting);
            if (IsLocalVariable(setting) && Parent != null)
                return GetLocalVariableValue(setting, Parent);
            return setting;
        }
    }
}
