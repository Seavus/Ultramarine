namespace Ultramarine.QueryLanguage.Comparers
{
    internal class StringComparerEquals : StringComparer
    {
        public override OperatorType Type => OperatorType.Equals;

        public override bool Evaluate(string leftOperand, string rightOperand)
        {
            var isValid = base.Validate(leftOperand, rightOperand);
            return isValid && leftOperand.Equals(rightOperand);
        }
    }
}
