using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Ultramarine.Generators.Serialization.Providers;
using Ultramarine.Generators.Tasks;

namespace Ultramarine.Generators.Tests
{
    [TestClass]
    public class CreateProjectItemTests
    {
        [TestMethod]
        [DeploymentItem("Samples\\CreateProjectItemTest.gen.json", "Samples")]
        public void ShouldDeserializeGeneratorConfig()
        {
            var generatorPath = "Samples\\CreateProjectItemTest.gen.json";
            var generator = GeneratorSerializer.Instance.Load(generatorPath, null);

            Assert.IsNotNull(generator);
            Assert.AreEqual(generator.Name, "generator1");
            Assert.AreEqual(generator.Description, "generator1description");
        }

        [TestMethod]
        [DeploymentItem("Samples\\CreateProjectItemTest.gen.json", "Samples")]
        public void ShouldDeserializeTaskCollection()
        {
            var generatorPath = "Samples\\CreateProjectItemTest.gen.json";
            var generator = GeneratorSerializer.Instance.Load(generatorPath, null);
            Assert.IsNotNull(generator.Tasks);
        }

        [TestMethod]
        [DeploymentItem("Samples\\CreateProjectItemTest.gen.json", "Samples")]
        public void TaskCollectionShouldHaveCreateFolderTask()
        {
            var generatorPath = "Samples\\CreateProjectItemTest.gen.json";
            var generator = GeneratorSerializer.Instance.Load(generatorPath, null);
            Assert.IsNotNull(generator.Tasks.FirstOrDefault());
            var createProjectItemTask = generator.Tasks.First();
            Assert.IsInstanceOfType(createProjectItemTask, typeof(CreateProjectItem));
            Assert.AreEqual(createProjectItemTask.Name, "createProjectItemTask1");
            Assert.AreEqual(createProjectItemTask.Description, "createProjectItemTask1description");
        }

    }
}
