using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Ultramarine.Generators.Serialization.Providers;
using Ultramarine.Generators.Tasks;

namespace Ultramarine.Generators.Tests
{
    [TestClass]
    public class CreateFolderTests
    {
        [TestMethod]
        [DeploymentItem("Samples\\CreateFolderTest.gen.json", "Samples")]
        public void ShouldDeserializeGeneratorConfig()
        {
            var generatorPath = "Samples\\CreateFolderTest.gen.json";
            var generator = GeneratorSerializer.Instance.Load(generatorPath);

            Assert.IsNotNull(generator);
            Assert.AreEqual(generator.Name, "generator1");
            Assert.AreEqual(generator.Description, "generator1description");
        }

        [TestMethod]
        [DeploymentItem("Samples\\CreateFolderTest.gen.json", "Samples")]
        public void ShouldDeserializeTaskCollection()
        {
            var generatorPath = "Samples\\CreateFolderTest.gen.json";
            var generator = GeneratorSerializer.Instance.Load(generatorPath);
            Assert.IsNotNull(generator.Tasks);
        }

        [TestMethod]
        [DeploymentItem("Samples\\CreateFolderTest.gen.json", "Samples")]
        public void TaskCollectionShouldHaveCreateFolderTest()
        {
            var generatorPath = "Samples\\CreateFolderTest.gen.json";
            var generator = GeneratorSerializer.Instance.Load(generatorPath);
            Assert.IsNotNull(generator.Tasks.FirstOrDefault());
            var createFolderTask = generator.Tasks.First();
            Assert.IsInstanceOfType(createFolderTask, typeof(CreateFolder));
            Assert.AreEqual(createFolderTask.Name, "createFolderTask1");
            Assert.AreEqual(createFolderTask.Description, "createFolderTask1description");
        }



    }
}
