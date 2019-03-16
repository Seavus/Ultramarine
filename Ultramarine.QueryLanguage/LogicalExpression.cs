namespace Ultramarine.QueryLanguage
{
    public abstract class LogicalExpression
    {
        protected LogicalExpression(bool leftOperand, bool? rightOperand)
        {
            LeftOperand = leftOperand;
            RightOperand = rightOperand.HasValue ? rightOperand.Value : true;
        }

        protected LogicalExpression(ComparisonExpression leftOperand, ComparisonExpression rightOperand) 
        {
            LeftOperand = leftOperand.Evaluate();
            RightOperand = rightOperand == null ? true : rightOperand.Evaluate();
        }


        public bool LeftOperand { get; private set; }
        public bool RightOperand { get; private set; }

        public abstract bool Evaluate();
    }
}
