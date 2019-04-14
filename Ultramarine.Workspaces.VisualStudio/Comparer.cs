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

    public static class Condition
    {
        public static bool Check(string propertyName, string conditionTemplate)
        {
            var condition = conditionTemplate.Replace("${property}", propertyName);
            var compiler = new ConditionCompiler(condition);
            return (bool)compiler.Execute();
        }
    }

}
