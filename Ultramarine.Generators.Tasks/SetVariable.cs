using System.Collections.Generic;
using System.Composition;
using Ultramarine.Generators.Tasks.Library.Contracts;
using Ultramarine.Generators.Tasks.Library.Extensions;

namespace Ultramarine.Generators.Tasks
{
    /// <summary>
    /// Sets a variable in a local scope (a parent of a current task)
    /// </summary>
    [Export(typeof(Task))]
    public class SetVariable : Task
    {
        private string _variableName;

        /// <summary>
        /// Name of the variable to set
        /// <para>This property supports Variables</para>
        /// </summary>
        public string VariableName { get => TryGetSettingValue(_variableName) as string; set => _variableName = value; }
        /// <summary>
        /// Value of the variable to set
        /// </summary>
        public object VariableValue { get; set; }
        /// <summary>
        /// Name of the parent task to set a variable on
        /// </summary>
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
