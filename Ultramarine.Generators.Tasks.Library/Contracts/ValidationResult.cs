using System.Collections.Generic;

namespace Ultramarine.Generators.Tasks.Library.Contracts
{
    public class ValidationResult: Dictionary<string, string>
    {
        public bool IsValid { get { return Count == 0; } }
    }

}
