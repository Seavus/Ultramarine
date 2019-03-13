using System;
using Ultramarine.Generators.LanguageDefinitions;

namespace Ultramarine.Generators.Serialization.Providers
{
    public class GeneratorSerializer
    {
        /// <summary>
        /// Generator serializer is a thread-safe lazy singleton and can be re-used from any serialization context
        /// e.g. from a generator that imports other generator(s)
        /// </summary>
        private static readonly Lazy<GeneratorSerializer> _instance = new Lazy<GeneratorSerializer>(() => new GeneratorSerializer());
        public static GeneratorSerializer Instance { get { return _instance.Value; } }

        private GeneratorSerializer()
        {

        }
        
        public IGenerator Load()
        {
            throw new NotImplementedException();
        }
    }
}
