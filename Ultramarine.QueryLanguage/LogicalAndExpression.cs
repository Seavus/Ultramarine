namespace Ultramarine.QueryLanguage
{
    public class LogicalAndExpression: LogicalExpression
    {    

        public LogicalAndExpression(ComparisonExpression leftOperand, ComparisonExpression rightOperand) :
            base(leftOperand, rightOperand)
        {
        }

        public LogicalAndExpression(bool leftOperand, bool rightOperand) : base(leftOperand, rightOperand)
        {
        }

        public override bool Evaluate()
        {
            return LeftOperand && RightOperand;
        }
    }

}
