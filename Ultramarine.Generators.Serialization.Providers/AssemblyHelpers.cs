using System;
using System.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Ultramarine.Generators.Serialization.Providers
{
    public static class AssemblyHelpers
    {
        public static Type[] GetAllExportedTypes<T>()
        {
            var containerConfiguration = new ContainerConfiguration();
            var currentPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var taskLibraries = Directory.EnumerateFiles(currentPath, "Ultramarine*Tasks*.dll", SearchOption.AllDirectories);
            foreach (var taskLibrary in taskLibraries)
            {
                try
                {
                    var assembly = Assembly.LoadFrom(taskLibrary);
                    containerConfiguration.WithAssembly(assembly);
                }
                catch
                {
                    //TODO: logger
                }
            }
            var container = containerConfiguration.CreateContainer();
            var taskTypes = container.GetExports<T>().Select(c => c.GetType()).ToArray();
            return taskTypes;
        }
    }
}
