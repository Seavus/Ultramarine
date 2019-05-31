using System.Collections.Generic;

namespace Ultramarine.Generators.Tasks.Library.Contracts
{
    public class ValidationResult: Dictionary<string, string>
    {
        public ValidationResult()
        {

        }

        public ValidationResult(string property, string exception)
        {
            Add(property, exception);
        }
        public bool IsValid { get { return Count == 0; } }
    }

}
