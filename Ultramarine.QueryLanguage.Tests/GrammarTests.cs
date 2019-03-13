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
    }
}
