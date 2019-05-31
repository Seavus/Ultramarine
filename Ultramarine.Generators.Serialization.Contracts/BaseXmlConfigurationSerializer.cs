using System.Xml;
using System.Xml.Serialization;

namespace Ultramarine.Generators.Serialization.Contracts
{
    public abstract class BaseXmlConfigurationSerializer<T> : XmlSerializer, IConfigurationSerializer<T>
    {
        public string Path { get; }
        public BaseXmlConfigurationSerializer(string path, XmlAttributeOverrides overrides): base(typeof(T), overrides)
        {
            Path = path;
        }

        public T Load()
        {
            var reader = ReadXml(Path);
            var generator = (T)Deserialize(reader);
            OnConfigurationDeserialized(generator);
            return generator;
        }

        public static XmlTextReader ReadXml(string path)
        {
            var reader = new XmlTextReader(path);
            reader.Read();
            return reader;
        }

        public virtual void OnConfigurationDeserialized(T generator)
        {
            
        }
    }
}
