using System.Composition;
using Ultramarine.Generators.Tasks.Library.Contracts;
using Ultramarine.Workspaces;

namespace Ultramarine.Generators.Tasks.Library
{
    [Export(typeof(Task))]
    public class Generator : CompositeTask
    {
        
    }
}
