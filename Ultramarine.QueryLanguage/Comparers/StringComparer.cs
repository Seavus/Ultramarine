namespace Ultramarine.QueryLanguage.Comparers
{
    internal abstract class StringComparer
    {
        public abstract OperatorType Type { get; }
        public virtual bool Evaluate(string leftOperand, string rightOperand)
        {
            return Validate(leftOperand, rightOperand);
        }

        public virtual bool Validate(string leftOperand, string rightOperand)
        {
            return !(string.IsNullOrWhiteSpace(leftOperand) || string.IsNullOrWhiteSpace(rightOperand));
        }
    }
}
