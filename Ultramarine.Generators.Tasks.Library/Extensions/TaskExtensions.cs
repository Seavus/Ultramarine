using System;
using Ultramarine.Generators.Tasks.Library.Contracts;

namespace Ultramarine.Generators.Tasks.Library.Extensions
{
    public static class TaskExtensions
    {
        public static Task TryGetParentTask(this Task task, string name)
        {
            if (task == null)
                throw new ArgumentException(string.Format("Couldn't find parent with name {0}", name));
            return task.Name == name ? task : task.Parent.TryGetParentTask(name);
        }

    }
}
