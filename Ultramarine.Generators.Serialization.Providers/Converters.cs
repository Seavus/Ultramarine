using Newtonsoft.Json;
using Ultramarine.Generators.Tasks.Library.Contracts;

namespace Ultramarine.Generators.Serialization.Providers
{
    public static class Converters
    {
        public static JsonConverter[] ScanTaskConverters()
        {
            var knownTypes = AssemblyHelpers.GetAllExportedTypes<Task>();
            var converters = new [] {
                new TaskConverter(knownTypes)
            };
            return converters;
        }
        
    }
}
