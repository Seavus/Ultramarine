using System;

namespace Ultramarine.Workspaces.CodeElements
{
    [Serializable]
    public enum ElementOverride
    {
        None,
        Abstract,
        Virtual,
        Override,
        New,
        Sealed
    }
}
