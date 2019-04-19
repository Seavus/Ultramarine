using System.Collections.Generic;
using System.Linq;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ultramarine.Generators.Serialization.Providers;
using Ultramarine.Generators.Tasks;
using Ultramarine.Workspaces;

namespace Ultramarine.Generators.Tests
{
    [TestClass]
    public class SqlCommandTests
    {
        [TestMethod]
        [DeploymentItem("Samples\\SqlCommand\\SqlCommandTextUpdateTest.gen.json", "Samples")]
        public void ShouldDeserializeGeneratorConfig()
        {
            var generatorPath = "Samples\\SqlCommand\\SqlCommandTextUpdateTest.gen.json";
            var generator = GeneratorSerializer.Instance.Load(generatorPath);

            Assert.IsNotNull(generator);
            Assert.AreEqual(generator.Name, "generator1");
            Assert.AreEqual(generator.Description, "generator1description");
        }

        [TestMethod]
        [DeploymentItem("Samples\\SqlCommand\\SqlCommandTextUpdateTest.gen.json", "Samples")]
        public void ShouldDeserializeTaskCollection()
        {
            var generatorPath = "Samples\\SqlCommand\\SqlCommandTextUpdateTest.gen.json";
            var generator = GeneratorSerializer.Instance.Load(generatorPath);
            Assert.IsNotNull(generator.Tasks);
        }

        [TestMethod]
        [DeploymentItem("Samples\\SqlCommand\\SqlCommandTextUpdateTest.gen.json", "Samples")]
        public void TaskCollectionShouldHaveSqlCommandTest()
        {
            var generatorPath = "Samples\\SqlCommand\\SqlCommandTextUpdateTest.gen.json";
            var generator = GeneratorSerializer.Instance.Load(generatorPath);
            Assert.IsNotNull(generator.Tasks.FirstOrDefault());
            var SqlCommandTask = generator.Tasks.First();
            Assert.IsInstanceOfType(SqlCommandTask, typeof(SqlCommand));
            Assert.AreEqual(SqlCommandTask.Name, "SqlCommandTextUpdate");
            Assert.AreEqual(SqlCommandTask.Description, "SqlCommandTextUpdateDescription");
        }

        //[TestMethod]
        //[DeploymentItem("Samples\\SqlCommand\\SqlCommandTextSelectTest.gen.json", "Samples")]
        //public void ShouldExecuteSelectSqlCommand()
        //{
        //    var generatorPath = "Samples\\SqlCommand\\SqlCommandTextSelectTest.gen.json";
        //    var generator = GeneratorSerializer.Instance.Load(generatorPath);
        //    var loggerMock = new Mock<ILogger>();

        //    generator.SetLogger(loggerMock.Object);
        //    generator.Execute();

        //    var task = generator.Tasks.First();
        //    List<List<object>> res = (List<List<object>>)task.Output;

        //    Assert.AreEqual(res.Count, 1); //temporary (num of rows)
        //}

        //[TestMethod]
        //[DeploymentItem("Samples\\SqlCommand\\SqlCommandTextUpdateTest.gen.json", "Samples")]
        //public void ShouldExecuteUpdateSqlCommand()
        //{
        //    var generatorPath = "Samples\\SqlCommand\\SqlCommandTextUpdateTest.gen.json";
        //    var generator = GeneratorSerializer.Instance.Load(generatorPath);
        //    var loggerMock = new Mock<ILogger>();

        //    generator.SetLogger(loggerMock.Object);
        //    generator.Execute();

        //    var task = generator.Tasks.First();            
        //    Assert.AreEqual(task.Output, 1);
        //}

        //[TestMethod]
        //[DeploymentItem("Samples\\SqlCommand\\SqlCommandTextDeleteTest.gen.json", "Samples")]
        //public void ShouldExecuteDeleteSqlCommand()
        //{
        //    var generatorPath = "Samples\\SqlCommand\\SqlCommandTextDeleteTest.gen.json";
        //    var generator = GeneratorSerializer.Instance.Load(generatorPath);
        //    var loggerMock = new Mock<ILogger>();

        //    generator.SetLogger(loggerMock.Object);
        //    generator.Execute();

        //    var task = generator.Tasks.First();
            
        //    Assert.AreEqual(task.Output, 1);
        //}

        //[TestMethod]
        //[DeploymentItem("Samples\\SqlCommand\\SqlCommandStoredProcedureSelectTest.gen.json", "Samples")]
        //public void ShouldExecuteStoredProcedure()
        //{
        //    var generatorPath = "Samples\\SqlCommand\\SqlCommandStoredProcedureSelectTest.gen.json";
        //    var generator = GeneratorSerializer.Instance.Load(generatorPath);
        //    var loggerMock = new Mock<ILogger>();

        //    generator.SetLogger(loggerMock.Object);
        //    generator.Execute();

        //    var task = generator.Tasks.First();
        //    List<List<object>> res = (List<List<object>>)task.Output;

        //    Assert.AreEqual(res[0].Count, 13); //temporary (num of rows)
        //}        
    }
}
