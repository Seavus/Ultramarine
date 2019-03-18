using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using Ultramarine.Generators.Tasks.Library.Contracts;

namespace Ultramarine.Generators.Serialization.Providers
{
    public class TaskConverter : JsonConverter
    {
        private readonly Type[] _knownTaskTypes;
        public TaskConverter(Type[] knownType)
        {
            _knownTaskTypes = knownType;
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Task); //typeof(Task).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var target = serializer.Deserialize<JObject>(reader);
            var concreteType = DetermineConcreteType(target);
            var result = Activator.CreateInstance(concreteType);
            serializer.Populate(target.First.First.CreateReader(), result);
            return result;

        }

        private Type DetermineConcreteType(JObject target)
        {
            var typeName = ((JProperty)target.First).Name;
            var type = _knownTaskTypes.First(t => t.Name.Equals(typeName, StringComparison.InvariantCultureIgnoreCase));
            return type;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}
