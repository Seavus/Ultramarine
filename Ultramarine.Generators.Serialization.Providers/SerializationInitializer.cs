using System;
using System.IO;
using Ultramarine.Generators.Serialization.Contracts;
using Ultramarine.Generators.Tasks.Library;
using Ultramarine.Workspaces;

namespace Ultramarine.Generators.Serialization.Providers
{
    public static class SerializationInitializer
    {
        public static IConfigurationSerializer<Generator> Initialize(string refGeneratorPath)
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
