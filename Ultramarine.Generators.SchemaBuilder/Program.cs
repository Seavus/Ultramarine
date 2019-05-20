using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;
using Newtonsoft.Json.Serialization;
using NJsonSchema;
using Ultramarine.Generators.Serialization.Providers;
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

            //var objectTypes = AssemblyHelpers.GetAllExportedTypes<Task>();

            //List<JSchema> schemas = new List<JSchema>();
            //foreach (var o in objectTypes)
            //{
            //    var generator = new JSchemaGenerator();
            //    //generator.GenerationProviders.Add(new TaskProvider());
            //    var schema = generator.Generate(o);
            //    schemas.Add(schema);
            //}

            JSchemaGenerator generator = new JSchemaGenerator();
            generator.GenerationProviders.Add(new TaskProvider());

            var schema = generator.Generate(typeof(Generator));
            Console.Write(schema.ToString());
            Console.ReadLine();
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
            
            var objectTypes = AssemblyHelpers.GetAllExportedTypes<Task>();

            JSchema sssss = new JSchema();
            foreach (var type in objectTypes)
            {
                sssss.AnyOf.Add(generator.Generate(type));
            }

            JSchemaGenerator stringEnumGenerator = new JSchemaGenerator();
            stringEnumGenerator.GenerationProviders.Add(new StringEnumGenerationProvider());

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
