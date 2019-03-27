using System;
using System.Collections.Generic;
using System.Linq;

namespace Ultramarine.QueryLanguage.Comparers
{
    internal class StringComparison
    {
        private static readonly Lazy<StringComparison> _instance = new Lazy<StringComparison>(() => new StringComparison());
        public static StringComparison Instance { get { return _instance.Value; } }

        //flyweight all the way
        private StringComparison()
        {
            _comparers = InitializeComparers();
        }

        private List<StringComparer> _comparers;

        private static List<StringComparer> InitializeComparers()
        {
            return new List<StringComparer>()
            {
                new StringComparerEquals(),
                new StringComparerStartsWith(),
                new StringComparerEndsWith(),
                new StringComparerContains()
            };
        }

        public StringComparer GetComparer(OperatorType operatorType)
        {
            var comparer = _comparers.FirstOrDefault(c => c.Type == operatorType);
            if (comparer == null)
                throw new ArgumentException("Unsupported operator type");
            return comparer;
        }

        public void RegisterComparer(StringComparer comparer)
        {
            //TODO:
            _comparers.Add(comparer);
        }
        
    }
}
