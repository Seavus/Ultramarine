using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ultramarine.QueryLanguage.Tests
{
    [TestClass]
    public class StartsWithTests
    {
        [TestMethod]
        public void ShouldEvaluateStartsWithConditionAsFalse()
        {
            var expression = "'Test1' startsWith 'Test2'";
            var compiler = new ConditionCompiler(expression);
            var result = (bool)compiler.Execute();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ShouldEvaluateStartsWithConditionAsTrue()
        {
            var expression = "'Test1' startsWith 'Test1'";
            var compiler = new ConditionCompiler(expression);
            var result = (bool)compiler.Execute();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ShouldEvaluateStartsWithWithNoContainingString()
        {
            var expression = "'test1' startsWith 'p'";
            var compiler = new ConditionCompiler(expression);
            var result = (bool)compiler.Execute();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ShouldEvaluateStartsWithConditionAsTrueWrappedInParens()
        {
            var expression = "('Test1' startsWith 'te')";
            var compiler = new ConditionCompiler(expression);
            var result = (bool)compiler.Execute();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ShouldEvaluateConditionsContainingFalseKeyword()
        {
            var expression = "false startsWith false";
            var compiler = new ConditionCompiler(expression);
            var result = (bool)compiler.Execute();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ShouldEvaluateConditionsContainingTrueKeyword()
        {
            var expression = "true startsWith true";
            var compiler = new ConditionCompiler(expression);
            var result = (bool)compiler.Execute();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ShouldEvaluateConditionsContainingCombinedKeyword()
        {
            var expression = "true startsWith false";
            var compiler = new ConditionCompiler(expression);
            var result = (bool)compiler.Execute();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ShouldEvaluateAndTruthyComplexConditions()
        {
            var expression = "'Test1' startsWith 'Test1' and 'Test2' startsWith 'Test2'";
            var compiler = new ConditionCompiler(expression);
            var result = (bool)compiler.Execute();

            Assert.IsTrue(result);
        }


        [TestMethod]
        public void ShouldEvaluateAndTruthyComplexConditionsWrappedInParens()
        {
            var expression = "('Test1' startsWith 'Test1') and ('Test2' startsWith 'Test2')";
            var compiler = new ConditionCompiler(expression);
            var result = (bool)compiler.Execute();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ShouldEvaluateFalsyComplexConditions()
        {
            var expression = "'Test2' startsWith 'Test1' and 'Test2' startsWith 'Test2'";
            var compiler = new ConditionCompiler(expression);
            var result = (bool)compiler.Execute();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ShouldEvaluateFalseComplexConditions()
        {
            var expression = "'Test2' startsWith 'Test1' and 'Test1' startsWith 'Test2'";
            var compiler = new ConditionCompiler(expression);
            var result = (bool)compiler.Execute();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ShouldEvaluateOrTruthyComplexConditions()
        {
            var expression = "'Test1' startsWith 'Test1' or 'Test2' startsWith 'Test2'";
            var compiler = new ConditionCompiler(expression);
            var result = (bool)compiler.Execute();

            Assert.IsTrue(result);
        }
    }
}
