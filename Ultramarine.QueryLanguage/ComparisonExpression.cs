using System;
using Ultramarine.QueryLanguage.Comparers;
using StringComparer = Ultramarine.QueryLanguage.Comparers.StringComparer;
using StringComparison = Ultramarine.QueryLanguage.Comparers.StringComparison;

namespace Ultramarine.QueryLanguage
{
    public class ComparisonExpression
    {
        public ComparisonExpression(string @operator, string leftOperand, string rightOperand)
            : this((OperatorType)Enum.Parse(typeof(OperatorType), @operator, true), leftOperand, rightOperand)
        {
            
        }

        public ComparisonExpression(OperatorType operatorType, string leftOperand, string rightOperand)
        {
            _comparer = StringComparison.Instance.GetComparer(operatorType);
            LeftOperand = leftOperand;
            RightOperand = rightOperand;
        }
        private StringComparer _comparer;
        public OperatorType OperatorType { get; private set; }
        public string LeftOperand { get; private set; }
        public string RightOperand { get; private set; }

        public bool Evaluate()
        {
            return _comparer.Evaluate(LeftOperand, RightOperand);
        }
        

        //private StringComparer ParseComparisonType(string @operator)
        //{
        //    OperatorType = (OperatorType)Enum.Parse(typeof(OperatorType), @operator, true);
        //    return StringComparison.Instance.GetComparer(OperatorType);
        //}
    }

}
