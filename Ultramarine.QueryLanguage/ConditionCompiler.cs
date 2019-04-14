using Antlr4.Runtime;
using System;
using Ultramarine.QueryLanguage.Grammars;

namespace Ultramarine.QueryLanguage
{
    public class ConditionCompiler
    {
        public const string ThisAlias = "$this";
        public ConditionCompiler(string expression)
        {
            var input = new AntlrInputStream(expression);
            var lexer = new QueryLanguageLexer(input);
            var tokens = new CommonTokenStream(lexer);
            var parser = new QueryLanguageParser(tokens);            
            var visitor = new LogicalExpressionVisitor();
            OriginalExpression = expression;
            Expression = visitor.Visit(parser.condition().LogicalExpression);
            if (Expression == null)
                throw new ArgumentException($"Given expression '{expression}' cannot be parsed.");
        }

        public ConditionCompiler(string expression, string value)
            :this(expression.Replace(ThisAlias, $"'{value}'"))
        {

        }

        public LogicalExpression Expression { get; private set; }
        public string OriginalExpression { get; private set; }

        public bool Execute()
        {
            return Expression.Evaluate();
        }

        
    }
}
