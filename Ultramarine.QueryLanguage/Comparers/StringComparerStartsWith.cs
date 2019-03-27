using System.Globalization;

namespace Ultramarine.QueryLanguage.Comparers
{
    internal class StringComparerStartsWith : StringComparer
    {
        public override OperatorType Type => OperatorType.StartsWith;

        public override bool Evaluate(string leftOperand, string rightOperand)
        {
            var isValid = base.Validate(leftOperand, rightOperand);
            return isValid && leftOperand.StartsWith(rightOperand, true, CultureInfo.InvariantCulture);
        }
    }
}
