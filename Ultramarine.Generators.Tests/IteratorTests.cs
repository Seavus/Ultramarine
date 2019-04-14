using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ultramarine.Generators.Serialization.Providers;
using Ultramarine.Generators.Tasks;

namespace Ultramarine.Generators.Tests
{
    [TestClass]
    public class IteratorTests
    {
        [TestMethod]
        [DeploymentItem("Samples\\IteratorTest.gen.json", "Samples")]
        public void ShouldDeserializeGeneratorConfig()
        {
            var generatorPath = "Samples\\IteratorTest.gen.json";
            var generator = GeneratorSerializer.Instance.Load(generatorPath);

            Assert.IsNotNull(generator);
            Assert.AreEqual(generator.Name, "generator1");
            Assert.AreEqual(generator.Description, "generator1description");
        }

        [TestMethod]
        [DeploymentItem("Samples\\IteratorTest.gen.json", "Samples")]
        public void ShouldDeserializeTaskCollection()
        {
            var generatorPath = "Samples\\IteratorTest.gen.json";
            var generator = GeneratorSerializer.Instance.Load(generatorPath);
            Assert.IsNotNull(generator.Tasks);
        }

        [TestMethod]
        [DeploymentItem("Samples\\IteratorTest.gen.json", "Samples")]
        public void TaskCollectionShouldHaveIteratorTask()
        {
            var generatorPath = "Samples\\IteratorTest.gen.json";
            var generator = GeneratorSerializer.Instance.Load(generatorPath);
            Assert.IsNotNull(generator.Tasks.FirstOrDefault());
            var iteratorTask = generator.Tasks.First();
            Assert.IsInstanceOfType(iteratorTask, typeof(Iterator));
            Assert.AreEqual(iteratorTask.Name, "iteratorTask1");
            Assert.AreEqual(iteratorTask.Description, "iteratorTask1Description");
        }

    }
}
