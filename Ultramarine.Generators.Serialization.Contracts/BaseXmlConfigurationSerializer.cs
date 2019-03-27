using System.Xml.Serialization;

namespace Ultramarine.Generators.Serialization.Contracts
{
    public abstract class BaseXmlConfigurationSerializer<T> : XmlSerializer, IConfigurationSerializer<T>
    {
        public T Load()
        {
            throw new System.NotImplementedException();
        }

        public void OnConfigurationDeserialized(T generator)
        {
            throw new System.NotImplementedException();
        }
    }
}
