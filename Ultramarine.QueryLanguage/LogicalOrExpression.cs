namespace Ultramarine.QueryLanguage
{
    public class LogicalOrExpression : LogicalExpression
    {
        public LogicalOrExpression(bool leftOperand, bool rightOperand) : base(leftOperand, rightOperand)
        {
        }

        public LogicalOrExpression(ComparisonExpression leftOperand, ComparisonExpression rightOperand) : base(leftOperand, rightOperand)
        {
        }

        public override bool Evaluate()
        {
            return LeftOperand || RightOperand;
        }
    }

}
