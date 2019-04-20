using System;
using System.Composition;
using Ultramarine.Generators.Tasks.Library.Contracts;

namespace Ultramarine.Generators.Tasks
{
    [Export(typeof(Task))]
    public class ReadProperty : Task
    {
        public string PropertyName { get; set; }

        protected override object OnExecute()
        {
            var propertyInfo = Input.GetType().GetProperty(PropertyName);
            if(propertyInfo == null)
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
