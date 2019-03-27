using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Host;
using Ultramarine.Workspaces;

namespace Ultramarine.Roslyn
{
    public class UltramarineWorkspace : Workspace, IWorkspaceModel
    {
        public UltramarineWorkspace(HostServices host, string workspaceKind) : base(host, workspaceKind)
        {
        }
    }
}
