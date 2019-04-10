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
    public class LoadProjectItemTests
    {
        [TestMethod]
        [DeploymentItem("Samples\\LoadProjectItemTest.gen.json", "Samples")]
        public void ShouldDeserializeGeneratorConfig()
        {
            var generatorPath = "Samples\\LoadProjectItemTest.gen.json";
            var generator = GeneratorSerializer.Instance.Load(generatorPath);

            Assert.IsNotNull(generator);
            Assert.AreEqual(generator.Name, "generator1");
            Assert.AreEqual(generator.Description, "generator1description");
        }

        [TestMethod]
        [DeploymentItem("Samples\\LoadProjectItemTest.gen.json", "Samples")]
        public void ShouldDeserializeTaskCollection()
        {
            var generatorPath = "Samples\\LoadProjectItemTest.gen.json";
            var generator = GeneratorSerializer.Instance.Load(generatorPath);
            Assert.IsNotNull(generator.Tasks);
        }

        [TestMethod]
        [DeploymentItem("Samples\\LoadProjectItemTest.gen.json", "Samples")]
        public void TaskCollectionShouldHaveIteratorTask()
        {
            var generatorPath = "Samples\\LoadProjectItemTest.gen.json";
            var generator = GeneratorSerializer.Instance.Load(generatorPath);
            Assert.IsNotNull(generator.Tasks.FirstOrDefault());
            var iteratorTask = generator.Tasks.First();
            Assert.IsInstanceOfType(iteratorTask, typeof(LoadProjectItem));
            Assert.AreEqual(iteratorTask.Name, "loadProjectItemTask1");
            Assert.AreEqual(iteratorTask.Description, "loadProjectItemTask1Description");
        }

    }
}
