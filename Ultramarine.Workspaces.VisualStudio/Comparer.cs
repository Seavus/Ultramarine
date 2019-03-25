using Ultramarine.QueryLanguage;
using Ultramarine.QueryLanguage.Comparers;

namespace Ultramarine.Workspaces.VisualStudio
{
    public class Comparer
    {
        private string _leftOperand;
        private OperatorType _operatorType;
        public Comparer(string value, OperatorType operatorType)
        {
            _leftOperand = value;
            _operatorType = operatorType;
        }
        public bool Check(string value)
        {
            var expression = new ComparisonExpression(_operatorType, _leftOperand, value);
            return expression.Evaluate();
        }
    }

}
