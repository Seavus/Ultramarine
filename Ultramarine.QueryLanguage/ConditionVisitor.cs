using System.Collections.Generic;
using Antlr4.Runtime.Misc;
using Ultramarine.QueryLanguage.Grammars;

namespace Ultramarine.QueryLanguage
{
    public class ComparisonExpressionVisitor : QueryLanguageBaseVisitor<ComparisonExpression>
    {
        public override ComparisonExpression VisitComparisonExpressionWithOperators([NotNull] QueryLanguageParser.ComparisonExpressionWithOperatorsContext context)
        {
            var operandVisitor = new OperandVisitor();
            var leftOperand = operandVisitor.Visit(context.LeftOperand);
            var rightOperand = operandVisitor.Visit(context.RightOperand);

            var condition = new ComparisonExpression(context.Operator.GetText(), leftOperand, rightOperand);
            return condition;
        }

        public override ComparisonExpression VisitComparisonExpressionInParens([NotNull] QueryLanguageParser.ComparisonExpressionInParensContext context)
        {
            return Visit(context.comparison_expression());
        }

        public override ComparisonExpression VisitLogicalVariable([NotNull] QueryLanguageParser.LogicalVariableContext context)
        {
            return Visit(context.STRING());
        }
    }
}
