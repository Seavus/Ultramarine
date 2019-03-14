using System.Collections.Generic;

namespace Ultramarine.Generators.Task.Library.Contracts
{
    public class ValidationResult: Dictionary<string, string>
    {
        public bool IsValid { get { return Count == 0; } }
    }

}
