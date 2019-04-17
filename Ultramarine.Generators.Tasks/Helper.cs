using System;
using System.Collections.Generic;
using System.Text;

namespace Ultramarine.Generators.Tasks
{
    public class Helper
    {
        public static Dictionary<string, string> HungarianPrefixes = new Dictionary<string, string>()
        {
            {"i", typeof(int).Name},
            {"li", typeof(Int32).Name},
            {"s", typeof(Int16).Name},
            {"f", typeof(float).Name},
            {"db", typeof(double).Name},
            {"b", typeof(bool).Name},
            {"c", typeof(char).Name},
            {"str", typeof(string).Name}
        };
    }
}
