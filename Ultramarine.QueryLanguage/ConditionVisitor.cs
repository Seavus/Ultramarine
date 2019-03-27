using System.Collections.Generic;
using Antlr4.Runtime.Misc;
using Ultramarine.QueryLanguage.Grammars;

namespace Ultramarine.QueryLanguage
{
    public class ComparisonExpressionVisitor : QueryLanguageBaseVisitor<ComparisonExpression>
    {
        public override ComparisonExpression VisitComparisonExpressionWithOperators([NotNull] QueryLanguageParser.ComparisonExpressionWithOperatorsContext context)
        {
            var condition = new ComparisonExpression(context.Operator.GetText(), context.LeftOperand.GetText(), context.RightOperand.GetText());
            return condition;
        }

        public override ComparisonExpression VisitComparisonExpressionInParens([NotNull] QueryLanguageParser.ComparisonExpressionInParensContext context)
        {
            return Visit(context.comparison_expression());
        }
    }
}
