using System;
using System.Collections.Generic;
using System.Composition;
using System.Text;
using System.Text.RegularExpressions;
using Ultramarine.Generators.Tasks.Library.Contracts;

namespace Ultramarine.Generators.Tasks
{
    /// <summary>
    /// Converts, formats and replaces a string
    /// </summary>
    [Export(typeof(Task))]
    public class StringManipulation : Task
    {
        private string _pattern;
        private string _replacement;

        /// <summary>
        /// String format to apply
        /// </summary>
        public string Format { get; set; }
        public CaseType? Type { get; set; }
        /// <summary>
        /// String pattern to apply
        /// <para>This property supports Variables</para>
        /// </summary>
        public string Pattern { get => TryGetSettingValue(_pattern) as string; set => _pattern = value; }
        /// <summary>
        /// String replacement to apply (usually a Regex)
        /// <para>This property supports Variables</para>
        /// </summary>
        public string Replacement { get => TryGetSettingValue(_replacement) as string; set => _replacement = value; }


        protected override object OnExecute()
        {
            var convertedString = ConvertCase(Type, Convert.ToString(Input));
            var formattedString = FormatValue(convertedString, Format);
            var replacedString = Replace(formattedString, Pattern, Replacement);

            return replacedString;
        }

        private static string FormatValue(object value, string format)
        {
            if (string.IsNullOrEmpty(format))
                return value.ToString();

            return string.Format(format, value);
        }

        private static string Replace(object value, string pattern, string replacement)
        {
            if (string.IsNullOrEmpty(pattern) || string.IsNullOrEmpty(replacement))
                return Convert.ToString(value);
            return Regex.Replace(value.ToString(), pattern, replacement);
        }


        private static string ConvertCase(CaseType? type, string input)
        {
            var result = input;

            switch (type)
            {
                case CaseType.Lower:
                    result = result.ToLower();
                    break;
                case CaseType.Upper:
                    result = result.ToUpper();
                    break;
                case CaseType.CamelCase:
                    result = ToCamelCase(result);
                    break;
                case CaseType.Hungarian:
                    result = ToHungarianCase(result);
                    break;
                default:
                    break;
            }

            return result;
        }

        private static string ToCamelCase(string value)
        {
            return value.Substring(0, 1).ToLower() + value.Substring(1);
        }

        private static string ToHungarianCase(string value)
        {
            return value.Substring(0, 1).ToUpper() + value.Substring(1);

            //var type = Input.GetType().Name;
            //var prefix = string.Empty;
            //Helper.HungarianPrefixes.TryGetValue(type, out prefix);
            //if (!string.IsNullOrEmpty(prefix))
            //    Input = $"{prefix}{Input.ToString()}";
        }
    }


    public enum CaseType
    {
        Upper,
        Lower,
        CamelCase,
        Hungarian
    }
}
