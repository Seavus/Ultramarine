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
            var conditioner = parser.conditioner();
            ConditionVisitor visitor = new ConditionVisitor();
            _condition = visitor.Visit(conditioner.condition());
        }

        private Condition _condition;

        public object Execute()
        {
            return _condition.Evaluate();
        }
    }
}
