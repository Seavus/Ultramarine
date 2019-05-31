using System;
using System.Composition;
using Ultramarine.Generators.Tasks.Library.Contracts;

namespace Ultramarine.Generators.Tasks
{
    /// <summary>
    /// Reads a value of the property from an input
    /// </summary>
    [Export(typeof(Task))]
    public class ReadProperty : Task
    {
        private string _propertyName;

        /// <summary>
        /// Name of the Code Element to load
        /// <para>This property supports Variables</para>
        /// </summary>
        public string PropertyName { get => TryGetSettingValue(_propertyName) as string; set => _propertyName = value; }

        protected override object OnExecute()
        {
            var propertyInfo = Input.GetType().GetProperty(PropertyName);
            if (propertyInfo == null)
                throw new ArgumentException($"Property {PropertyName} doesn't exist.\n{GetInputDescriptor(Input)}");
            var value = propertyInfo.GetValue(Input);
            if (value == null)
                throw new ArgumentException($"Property {PropertyName} doesn't have a value.");
            return value;

        }

        private string GetInputDescriptor(object input)
        {
            var descriptor = $"Input type: {input.GetType()}\n";
            descriptor += "Available properties: \n";
            foreach (var propertyInfo in input.GetType().GetProperties())
            {
                descriptor += $"{propertyInfo.Name} \n";
            }

            return descriptor;
        }

        protected override ValidationResult Validate()
        {
            if (string.IsNullOrWhiteSpace(PropertyName))
                return new ValidationResult(nameof(PropertyName), "Property name must be specified.");
            if (Input == null)
                return new ValidationResult(nameof(Input), "Input must be specified.");
            return base.Validate();
        }
    }
}
