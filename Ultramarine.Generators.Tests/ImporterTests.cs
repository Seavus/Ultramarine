using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.IO;
using System.Linq;
using System.Reflection;
using Ultramarine.Generators.Serialization.Providers;
using Ultramarine.Generators.Tasks.Complex;
using Ultramarine.Workspaces;

namespace Ultramarine.Generators.Tests
{
    [TestClass]
    public class ImporterTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        [DeploymentItem(@"Samples\Impoter\ImporterTest.gen.json", "Samples")]
        public void ShouldDeserializeGeneratorConfig()
        {
            var generatorPath = @"Samples\Importer\ImporterTest.gen.json";
            var generator = GeneratorSerializer.Instance.Load(generatorPath);

            Assert.IsNotNull(generator);
            Assert.AreEqual(generator.Name, "importer1");
            Assert.AreEqual(generator.Description, "importer1description");
        }

        [TestMethod]
        [DeploymentItem(@"Samples\Impoter\ImporterTest.gen.json", "Samples")]
        public void GeneratorConfigShouldContainImporter()
        {
            var generatorPath = @"Samples\Importer\ImporterTest.gen.json";
            var generator = GeneratorSerializer.Instance.Load(generatorPath);
            var importer = generator.Tasks.FirstOrDefault(t => t.Name == "importerTask1") as Importer;

            Assert.IsNotNull(importer);
            Assert.AreEqual(importer.Path, "Generator1.gen.json");
        }

        [TestMethod]
        [DeploymentItem(@"Samples\Impoter\ImporterTest.gen.json", "Samples")]
        public void GeneratorConfigShouldExecute()
        {
            var generatorPath = @"Samples\Importer\ImporterTest.gen.json";
            var generator = GeneratorSerializer.Instance.Load(generatorPath);
            var loggerMock = new Mock<ILogger>();
            var project = new Mock<IProjectModel>();
            var workspace = new Mock<IWorkspaceModel>();

            project.SetupProperty(c => c.FilePath,
                Path.Combine(
                    Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    @"Samples\Importer"));
            project.Setup(c => c.GetWorkspace()).Returns(workspace.Object);

            generator.SetExecutionContext(project.Object);
            generator.SetLogger(loggerMock.Object);
            generator.Execute();

            Assert.IsNull(generator.Output);
        }
    }
}
