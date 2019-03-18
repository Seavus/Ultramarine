using System;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Ultramarine.Generators.Serialization.Providers
{
    public static class AssemblyHelpers
    {
        public static Type[] GetAllExportedTypes<T>()
        {
            var catalog = new AggregateCatalog();
            var currentDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            catalog.Catalogs.Add(new DirectoryCatalog(currentDir));
            var container = new CompositionContainer(catalog);
            var taskTypes = container.GetExports<T>().Where(c => c.Value != null).Select(c => c.Value.GetType()).ToArray();

            return taskTypes;
        }
    }
}
