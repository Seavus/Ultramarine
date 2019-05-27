using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Modeling.Diagrams;

namespace Ultramarine.Generators.Language
{
    partial class Task
    {
        public string GetBaseTypeValue()
        {
            return GetType().Name;
        }
    }    
}
