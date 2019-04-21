using System.Collections.Generic;
using System.Composition;
using Ultramarine.Generators.Tasks.Library.Contracts;
using Ultramarine.Generators.Tasks.Library.Extensions;

namespace Ultramarine.Generators.Tasks
{
    [Export(typeof(Task))]
    public class SetVariable : Task
    {
        public string VariableName { get; set; }
        public object VariableValue { get; set; }
        public string ParentTask { get; set; }

        protected override ValidationResult Validate()
        {
            if (string.IsNullOrWhiteSpace(VariableName))
                return new ValidationResult(nameof(VariableName), "Variable name must be specified.");
            if (VariableValue == null && Input == null)
                return new ValidationResult(nameof(VariableValue), "If the task is not connected with any other task, variable value must be specified.");
            return base.Validate();
        }

        protected override object OnExecute()
        {
            var parentTask = string.IsNullOrWhiteSpace(ParentTask) ? Parent : this.TryGetParentTask(ParentTask);
            var variableValue = VariableValue == null ? Input : VariableValue;
            var existingIndex = parentTask.Variables.FindIndex(v => v.Key == VariableName);
            if (existingIndex >= 0)
                parentTask.Variables.RemoveAt(existingIndex);
            parentTask.Variables.Add(new Variable(VariableName, variableValue));
            return variableValue;
        }
    }
}
