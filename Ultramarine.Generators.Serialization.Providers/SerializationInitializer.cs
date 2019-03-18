using System;
using System.IO;
using Ultramarine.Generators.Serialization.Contracts;
using Ultramarine.Generators.Tasks.Library;

namespace Ultramarine.Generators.Serialization.Providers
{
    public static class SerializationInitializer
    {
        public static IConfigurationSerializer<Generator> Initialize(string refGeneratorPath) //, Project executionContext)
        {
            var extension = Path.GetExtension(refGeneratorPath);
            switch (extension)
            {
                case SerializatorFileTypes.Xml:
                    //return new XmlConfigurationSerializer<Generator>(refGeneratorPath, executionContext,
                    //ConfigurationOverrides.FindTaskOverrides());
                    throw new NotImplementedException();
                case SerializatorFileTypes.Json:
                    return new JsonConfigurationSerializer<Generator>(refGeneratorPath, Converters.ScanTaskConverters());
                default:
                    throw new ArgumentException("Unsupported config file type.");
            }
        }
    }


}
