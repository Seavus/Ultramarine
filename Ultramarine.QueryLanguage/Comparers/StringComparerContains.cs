namespace Ultramarine.QueryLanguage.Comparers
{
    internal class StringComparerContains : StringComparer
    {
        public override OperatorType Type => OperatorType.Contains;

        public override bool Evaluate(string leftOperand, string rightOperand)
        {
            var isValid = base.Validate(leftOperand, rightOperand);
            return isValid && leftOperand.Contains(rightOperand);
        }
    }
}
