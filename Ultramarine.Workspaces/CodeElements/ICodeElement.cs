﻿using System.Collections.Generic;

namespace Ultramarine.Workspaces.CodeElements
{
    public interface ICodeElementModel
    {
        string Name { get; set; }
        ElementType? Type { get; set; }
        ElementAccess? Access { get; set; }
        ElementOverride Override { get; set; }
        List<string> TypeOf { get; set; }
        List<ICodeElementModel> Children { get; set; }
        List<ICodeElementModel> Attributes { get; }
    }
}
