using Newtonsoft.Json;
using System;

namespace Ultramarine.Generators.Serialization.Contracts
{
    public abstract class BaseJsonConfigurationSerializer<T> : JsonSerializer, IConfigurationSerializer<T>
    {
        public T Load()
        {
            throw new NotImplementedException();
        }
    }
}
