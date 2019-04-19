using System;

namespace Ultramarine.Workspaces.CodeElements
{
    [Serializable]
    public enum ElementType
    {
        Other = 0,
        Class = 1,
        Function = 2,
        Variable = 3,
        Property = 4,
        Namespace = 5,
        Parameter = 6,
        Attribute = 7,
        Interface = 8,
        Delegate = 9,
        Enum = 10,
        Struct = 11,
        Union = 12
    }
}
