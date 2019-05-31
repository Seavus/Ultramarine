using System;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;
using Newtonsoft.Json.Serialization;
using Ultramarine.Generators.Tasks.Library;
using Ultramarine.Generators.Tasks.Library.Contracts;

namespace Ultramarine.Generators.SchemaBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.OutputEncoding = System.Text.Encoding.GetEncoding(28591);
            Console.WriteLine(Logo.Art);
            Console.WriteLine("Ultramarine SchemaBuilder");
            Console.ResetColor();

            var generator = new JSchemaGenerator();
            generator.GenerationProviders.Add(new TaskProvider());
            generator.Generate(typeof(Generator));
        }
    }


    public class TaskProvider : JSchemaGenerationProvider
    {
        public override JSchema GetSchema(JSchemaTypeGenerationContext context)
        {
            if (context.ObjectType == typeof(TaskCollection))
                return CreateCollectionSchema();
            return null;
        }
        
        private JSchema CreateCollectionSchema()
        {
            JSchemaGenerator generator = new JSchemaGenerator();
            JSchema schema = generator.Generate(typeof(TaskCollection));
            //schema.Properties.Add()
            return schema;
        }
    }
    public class TaskResolver : IContractResolver
    {
        public JsonContract ResolveContract(Type type)
        {
            throw new NotImplementedException();
        }
    }
}
