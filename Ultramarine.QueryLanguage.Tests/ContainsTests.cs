using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ultramarine.QueryLanguage.Tests
{
    [TestClass]
    public class ContainsTests
    {
        [TestMethod]
        public void ShouldEvaluateContainsConditionAsFalse()
        {
            var expression = "'TestA' contains 'TestB'";
            var compiler = new ConditionCompiler(expression);
            var result = (bool)compiler.Execute();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ShouldEvaluateContainsConditionWithAliasAsFalse()
        {
            var expression = "$this contains 'Test2'";
            var compiler = new ConditionCompiler(expression);
            var result = (bool)compiler.Execute();

            Assert.IsFalse(result);

        }

        [TestMethod]
        public void ShouldEvaluateContainsConditionWithWhitespacesAsFalse()
        {
            var expression = "'Solution items' contains 'Test2'";
            var compiler = new ConditionCompiler(expression);
            var result = compiler.Execute();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ShouldEvaluateContainsConditionAsTrue()
        {
            var expression = "'Test1' contains 'Test1'";
            var compiler = new ConditionCompiler(expression);
            var result = (bool)compiler.Execute();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ShouldEvaluateContainsWithNoContainingString()
        {
            var expression = "'test1' contains 'p'";
            var compiler = new ConditionCompiler(expression);
            var result = (bool)compiler.Execute();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ShouldEvaluateContainsConditionAsTrueWrappedInParens()
        {
            var expression = "('Test1' contains 't1')";
            var compiler = new ConditionCompiler(expression);
            var result = (bool)compiler.Execute();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ShouldEvaluateConditionsContainingFalseKeyword()
        {
            var expression = "false contains false";
            var compiler = new ConditionCompiler(expression);
            var result = (bool)compiler.Execute();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ShouldEvaluateConditionsContainingTrueKeyword()
        {
            var expression = "true contains true";
            var compiler = new ConditionCompiler(expression);
            var result = (bool)compiler.Execute();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ShouldEvaluateConditionsContainingCombinedKeyword()
        {
            var expression = "true contains false";
            var compiler = new ConditionCompiler(expression);
            var result = (bool)compiler.Execute();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ShouldEvaluateAndTruthyComplexConditions()
        {
            var expression = "'Test1' contains 'Test1' and 'Test2' contains 'Test2'";
            var compiler = new ConditionCompiler(expression);
            var result = (bool)compiler.Execute();

            Assert.IsTrue(result);
        }


        [TestMethod]
        public void ShouldEvaluateAndTruthyComplexConditionsWrappedInParens()
        {
            var expression = "('Test1' contains 'Test1') and ('Test2' contains 'Test2')";
            var compiler = new ConditionCompiler(expression);
            var result = (bool)compiler.Execute();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ShouldEvaluateFalsyComplexConditions()
        {
            var expression = "'Test2' contains 'Test1' and 'Test2' contains 'Test2'";
            var compiler = new ConditionCompiler(expression);
            var result = (bool)compiler.Execute();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ShouldEvaluateFalseComplexConditions()
        {
            var expression = "'Test2' contains 'Test1' and 'Test1' contains 'Test2'";
            var compiler = new ConditionCompiler(expression);
            var result = (bool)compiler.Execute();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ShouldEvaluateOrTruthyComplexConditions()
        {
            var expression = "'Test1' contains 'Test1' or 'Test2' contains 'Test2'";
            var compiler = new ConditionCompiler(expression);
            var result = (bool)compiler.Execute();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ShouldEvaluateOrTruthyComplexConditionsWithSpecialOperands()
        {
            var expression = "'Test1.Test1' contains 'Test1' or 'Test2' contains 'Test2'";
            var compiler = new ConditionCompiler(expression);
            var result = (bool)compiler.Execute();

            Assert.IsTrue(result);
        }

    }

}
