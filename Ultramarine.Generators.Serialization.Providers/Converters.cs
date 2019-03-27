using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
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
