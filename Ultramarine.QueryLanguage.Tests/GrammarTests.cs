using Antlr4.Runtime;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ultramarine.QueryLanguage.Grammars;

namespace Ultramarine.QueryLanguage.Tests
{
    [TestClass]
    public class GrammarTests
    {
        
        [TestMethod]
        public void ShouldEvaluateEqualsConditionAsFalse()
        {
            var expression = "Test1 equals Test2";
            var compiler = new ConditionCompiler(expression);
            var result = (bool)compiler.Execute();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ShouldEvaluateEqualsConditionAsTrue()
        {
            var expression = "Test1 equals Test1";
            var compiler = new ConditionCompiler(expression);
            var result = (bool)compiler.Execute();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ShouldEvaluateEqualsConditionAsTrueWrappedInParens()
        {
            var expression = "(Test1 equals Test1)";
            var compiler = new ConditionCompiler(expression);
            var result = (bool)compiler.Execute();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ShouldEvaluateConditionsContainingFalseKeyword()
        {
            var expression = "false equals false";
            var compiler = new ConditionCompiler(expression);
            var result = (bool)compiler.Execute();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ShouldEvaluateConditionsContainingTrueKeyword()
        {
            var expression = "true equals true";
            var compiler = new ConditionCompiler(expression);
            var result = (bool)compiler.Execute();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ShouldEvaluateConditionsContainingCombinedKeyword()
        {
            var expression = "true equals false";
            var compiler = new ConditionCompiler(expression);
            var result = (bool)compiler.Execute();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ShouldEvaluateAndTruthyComplexConditions()
        {
            var expression = "Test1 equals Test1 and Test2 equals Test2";
            var compiler = new ConditionCompiler(expression);
            var result = (bool)compiler.Execute();

            Assert.IsTrue(result);
        }

       
        [TestMethod]
        public void ShouldEvaluateAndTruthyComplexConditionsWrappedInParens()
        {
            var expression = "(Test1 equals Test1) and (Test2 equals Test2)";
            var compiler = new ConditionCompiler(expression);
            var result = (bool)compiler.Execute();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ShouldEvaluateFalsyComplexConditions()
        {
            var expression = "Test2 equals Test1 and Test2 equals Test2";
            var compiler = new ConditionCompiler(expression);
            var result = (bool)compiler.Execute();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ShouldEvaluateFalseComplexConditions()
        {
            var expression = "Test2 equals Test1 and Test1 equals Test2";
            var compiler = new ConditionCompiler(expression);
            var result = (bool)compiler.Execute();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ShouldEvaluateOrTruthyComplexConditions()
        {
            var expression = "Test1 equals Test1 or Test2 equals Test2";
            var compiler = new ConditionCompiler(expression);
            var result = (bool)compiler.Execute();

            Assert.IsTrue(result);
        }
    }
}
