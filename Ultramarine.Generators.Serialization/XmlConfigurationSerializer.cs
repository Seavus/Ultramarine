using System.Xml.Serialization;
using Ultramarine.Generators.Serialization.Contracts;
using Ultramarine.Generators.Tasks.Library;

namespace Ultramarine.Generators.Serialization
{
    public class XmlConfigurationSerializer<T> : BaseXmlConfigurationSerializer<T> where T : Generator
    {
        public XmlConfigurationSerializer(string path, XmlAttributeOverrides overrides): base(path, overrides)
        {
        }
    }
}
