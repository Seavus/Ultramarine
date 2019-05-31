using Newtonsoft.Json;
using System.Xml.Serialization;
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

        public static XmlAttributeOverrides ScanTaskOverrides()
        {
            var taskTypes = AssemblyHelpers.GetAllExportedTypes<Task>();

            var aor = new XmlAttributeOverrides();
            var listAttribs = new XmlAttributes();
            foreach (var taskType in taskTypes)
            {
                listAttribs.XmlElements.Add(new XmlElementAttribute(taskType.Name, taskType));
            }
            aor.Add(typeof(CompositeTask), "Tasks", listAttribs);

            return aor;
        }

    }
}
