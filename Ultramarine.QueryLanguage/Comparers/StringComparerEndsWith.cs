namespace Ultramarine.QueryLanguage.Comparers
{
    internal class StringComparerEndsWith : StringComparer
    {
        public override OperatorType Type => OperatorType.EndsWith;

        public override bool Evaluate(string leftOperand, string rightOperand)
        {
            var isValid = base.Validate(leftOperand, rightOperand);
            return isValid && leftOperand.EndsWith(rightOperand);
        }
    }
}
