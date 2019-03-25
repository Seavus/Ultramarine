using Newtonsoft.Json;
using Ultramarine.Generators.Serialization.Contracts;
using Ultramarine.Generators.Tasks.Library;
using Ultramarine.Workspaces;

namespace Ultramarine.Generators.Serialization
{
    public class JsonConfigurationSerializer<T> : BaseJsonConfigurationSerializer<T> where T : Generator
    {
        private readonly IProjectModel _executionContext;
        public JsonConfigurationSerializer(string path, IProjectModel executionContext, JsonConverter[] converters) : base(path, converters)
        {
            _executionContext = executionContext;
        }

        public override void OnConfigurationDeserialized(T generator)
        {
            base.OnConfigurationDeserialized(generator);
            generator.SetExecutionContext(_executionContext);
        }
    }
}
