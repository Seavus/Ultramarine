using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ultramarine.Generators.Serialization.Providers;
using Ultramarine.Generators.Tasks;
using Ultramarine.Workspaces;

namespace Ultramarine.Generators.Tests
{
    [TestClass]
    public class WebDownloadTests
    {
        [TestMethod]
        [DeploymentItem("Samples\\WebDownload\\WebDownload.gen.json", "Samples")]
        public void ShouldDeserializeGeneratorConfig()
        {
            var generatorPath = "Samples\\WebDownload\\WebDownload.gen.json";
            var generator = GeneratorSerializer.Instance.Load(generatorPath);

            Assert.IsNotNull(generator);
            Assert.AreEqual(generator.Name, "generator1");
            Assert.AreEqual(generator.Description, "generator1description");
        }

        [TestMethod]
        [DeploymentItem("Samples\\WebDownload\\WebDownload.gen.json", "Samples")]
        public void ShouldDeserializeTaskCollection()
        {
            var generatorPath = "Samples\\WebDownload\\WebDownload.gen.json";
            var generator = GeneratorSerializer.Instance.Load(generatorPath);
            Assert.IsNotNull(generator.Tasks);
        }

        [TestMethod]
        [DeploymentItem("Samples\\WebDownload\\WebDownload.gen.json", "Samples")]
        public void TaskCollectionShouldHaveCreateFolderTest()
        {
            var generatorPath = "Samples\\WebDownload\\WebDownload.gen.json";
            var generator = GeneratorSerializer.Instance.Load(generatorPath);
            Assert.IsNotNull(generator.Tasks.FirstOrDefault());
            var SqlCommandTask = generator.Tasks.First();
            Assert.IsInstanceOfType(SqlCommandTask, typeof(WebDownload));
            Assert.AreEqual(SqlCommandTask.Name, "WebDownloadTask");
            Assert.AreEqual(SqlCommandTask.Description, "WebDownloadTaskDescription");
        }

        [TestMethod]
        [DeploymentItem("Samples\\WebDownload\\WebDownload.gen.json", "Samples")]
        public void ShouldDownloadFile()
        {
            var generatorPath = "Samples\\WebDownload\\WebDownload.gen.json";
            var generator = GeneratorSerializer.Instance.Load(generatorPath);
            var loggerMock = new Mock<ILogger>();

            generator.SetLogger(loggerMock.Object);
            generator.Execute();

            var task = generator.Tasks.First();

            Assert.AreEqual(task.Output, 1); //temporary (num of rows)
        }
    }
}
