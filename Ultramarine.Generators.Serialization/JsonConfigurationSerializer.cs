﻿using Newtonsoft.Json;
using Ultramarine.Generators.Serialization.Contracts;
using Ultramarine.Generators.Tasks.Library;

namespace Ultramarine.Generators.Serialization
{
    public class JsonConfigurationSerializer<T> : BaseJsonConfigurationSerializer<T> where T : Generator
    {
        public JsonConfigurationSerializer(string path, JsonConverter[] converters) : base(path, converters)
        {
        }        
    }
}
