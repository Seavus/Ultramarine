using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ultramarine.QueryLanguage.Tests
{
    [TestClass]
    public class EndsWithTests
    {
        [TestMethod]
        public void ShouldEvaluateEndsWithConditionAsFalse()
        {
            var expression = "Test1 endsWith Test2";
            var compiler = new ConditionCompiler(expression);
            var result = (bool)compiler.Execute();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ShouldEvaluateEndsWithConditionAsTrue()
        {
            var expression = "Test1 endsWith Test1";
            var compiler = new ConditionCompiler(expression);
            var result = (bool)compiler.Execute();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ShouldEvaluateEndsWithWithNoContainingString()
        {
            var expression = "test1 endsWith p";
            var compiler = new ConditionCompiler(expression);
            var result = (bool)compiler.Execute();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ShouldEvaluateEndsWithConditionAsTrueWrappedInParens()
        {
            var expression = "(Test1 endsWith t1)";
            var compiler = new ConditionCompiler(expression);
            var result = (bool)compiler.Execute();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ShouldEvaluateConditionsContainingFalseKeyword()
        {
            var expression = "false endsWith false";
            var compiler = new ConditionCompiler(expression);
            var result = (bool)compiler.Execute();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ShouldEvaluateConditionsContainingTrueKeyword()
        {
            var expression = "true endsWith true";
            var compiler = new ConditionCompiler(expression);
            var result = (bool)compiler.Execute();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ShouldEvaluateConditionsContainingCombinedKeyword()
        {
            var expression = "true endsWith false";
            var compiler = new ConditionCompiler(expression);
            var result = (bool)compiler.Execute();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ShouldEvaluateAndTruthyComplexConditions()
        {
            var expression = "Test1 endsWith Test1 and Test2 endsWith Test2";
            var compiler = new ConditionCompiler(expression);
            var result = (bool)compiler.Execute();

            Assert.IsTrue(result);
        }


        [TestMethod]
        public void ShouldEvaluateAndTruthyComplexConditionsWrappedInParens()
        {
            var expression = "(Test1 endsWith Test1) and (Test2 endsWith Test2)";
            var compiler = new ConditionCompiler(expression);
            var result = (bool)compiler.Execute();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ShouldEvaluateFalsyComplexConditions()
        {
            var expression = "Test2 endsWith Test1 and Test2 endsWith Test2";
            var compiler = new ConditionCompiler(expression);
            var result = (bool)compiler.Execute();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ShouldEvaluateFalseComplexConditions()
        {
            var expression = "Test2 endsWith Test1 and Test1 endsWith Test2";
            var compiler = new ConditionCompiler(expression);
            var result = (bool)compiler.Execute();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ShouldEvaluateOrTruthyComplexConditions()
        {
            var expression = "Test1 endsWith Test1 or Test2 endsWith Test2";
            var compiler = new ConditionCompiler(expression);
            var result = (bool)compiler.Execute();

            Assert.IsTrue(result);
        }
    }

}
