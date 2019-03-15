using Antlr4.Runtime;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ultramarine.QueryLanguage.Grammars;

namespace Ultramarine.QueryLanguage.Tests
{
    [TestClass]
    public class GrammarTests
    {
        [TestMethod]
        public void ShouldParseSimpleEqualsExpression()
        {
            var expression = "Test1 equals Test2";
            var input = new AntlrInputStream(expression);
            var lexer = new QueryLanguageLexer(input);
            var tokens = new CommonTokenStream(lexer);
            var parser = new QueryLanguageParser(tokens);

            var context = parser.conditioner();
            Assert.IsNull(context.exception);
        }

        [TestMethod]
        public void ShouldEvaluateEqualsConditionAsFalse()
        {
            var expression = "Test1 equals Test2";
            var input = new AntlrInputStream(expression);
            var lexer = new QueryLanguageLexer(input);
            var tokens = new CommonTokenStream(lexer);
            var parser = new QueryLanguageParser(tokens);

            var conditioner = parser.conditioner();
            ConditionVisitor visitor = new ConditionVisitor();
            var condition = visitor.Visit(conditioner.condition());
            var result = condition.Evaluate();

            Assert.IsNotNull(condition.LeftOperand);
            Assert.IsNotNull(condition.RightOperand);
            Assert.IsNotNull(condition.OperatorType);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ShouldEvaluateEqualsConditionAsTrue()
        {
            var expression = "Test1 equals Test1";
            var input = new AntlrInputStream(expression);
            var lexer = new QueryLanguageLexer(input);
            var tokens = new CommonTokenStream(lexer);
            var parser = new QueryLanguageParser(tokens);

            var conditioner = parser.conditioner();
            ConditionVisitor visitor = new ConditionVisitor();
            var condition = visitor.Visit(conditioner.condition());
            var result = condition.Evaluate();

            Assert.IsNotNull(condition.LeftOperand);
            Assert.IsNotNull(condition.RightOperand);
            Assert.IsNotNull(condition.OperatorType);

            Assert.IsTrue(result);
        }


    }
}
