using Antlr4.Runtime;
using Ultramarine.QueryLanguage.Grammars;

namespace Ultramarine.QueryLanguage
{
    public class ConditionCompiler
    {
        public ConditionCompiler(string expression)
        {
            var input = new AntlrInputStream(expression);
            var lexer = new QueryLanguageLexer(input);
            var tokens = new CommonTokenStream(lexer);
            var parser = new QueryLanguageParser(tokens);            
            var visitor = new LogicalExpressionVisitor();
            _condition = visitor.Visit(parser.condition().LogicalExpression);
        }

        private LogicalExpression _condition;

        public object Execute()
        {
            return _condition.Evaluate();
        }
    }
}
