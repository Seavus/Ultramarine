using Antlr4.Runtime.Misc;
using Ultramarine.QueryLanguage.Grammars;

namespace Ultramarine.QueryLanguage
{
    public class LogicalExpressionVisitor : QueryLanguageBaseVisitor<LogicalExpression>
    {
        public override LogicalExpression VisitLogicalAndExpression([NotNull] QueryLanguageParser.LogicalAndExpressionContext context)
        {
            var comparisonVisitor = new ComparisonExpressionVisitor();
            var leftComparisonExpression = comparisonVisitor.Visit(context.LeftExpression);
            var rightComparisonExpression = comparisonVisitor.Visit(context.RightExpression);
            return new LogicalAndExpression(leftComparisonExpression, rightComparisonExpression);
        }

        public override LogicalExpression VisitLogicalOrExpression([NotNull] QueryLanguageParser.LogicalOrExpressionContext context)
        {
            var comparisonVisitor = new ComparisonExpressionVisitor();
            var leftComparisonExpression = comparisonVisitor.Visit(context.LeftExpression);
            var rightComparisonExpression = comparisonVisitor.Visit(context.RightExpression);
            return new LogicalOrExpression(leftComparisonExpression, rightComparisonExpression);
        }

        public override LogicalExpression VisitComparisonExpressionWithOperators([NotNull] QueryLanguageParser.ComparisonExpressionWithOperatorsContext context)
        {
            var comparisonVisitor = new ComparisonExpressionVisitor();
            var leftComparisonExpression = comparisonVisitor.Visit(context);
            return new LogicalAndExpression(leftComparisonExpression, null);
        }

        public override LogicalExpression VisitComparisonExpressionInParens([NotNull] QueryLanguageParser.ComparisonExpressionInParensContext context)
        {
            return Visit(context.comparison_expression());
        }

        public override LogicalExpression VisitLogicalExpressionInParen([NotNull] QueryLanguageParser.LogicalExpressionInParenContext context)
        {
            return Visit(context.logical_expression());
        }
    }    
}
