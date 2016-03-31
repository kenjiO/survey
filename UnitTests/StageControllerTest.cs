using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Evaluation.Controller;
using Test;

namespace UnitTests
{
    [TestClass]
    public class StageControllerTest
    {
        IEvaluationController controller = new EvaluationController(new TestDAL());

        [TestMethod]
        public void whenStageExistsStage1ShouldReturnTrue()
        {
            Assert.IsTrue(controller.StageExists("Stage 1"));
        }

        [TestMethod]
        public void whenStageExistsStage100ShouldReturnFalse()
        {
            Assert.IsFalse(controller.StageExists("Stage 100"));
        }

        [TestMethod]
        public void whenGetStageNameForId1ShouldGetStage1()
        {
            Assert.AreEqual("Stage 1", controller.GetStageName(1));
        }

        [TestMethod]
        public void whenGetStageNameForId100ShouldGetEmptyString()
        {
            Assert.AreEqual("", controller.GetStageName(100));
        }

        [TestMethod]
        public void whenGetNextStageIdForIdNullShouldGetStage1()
        {
            Assert.AreEqual(1, controller.GetNextStageId(null));
        }

        [TestMethod]
        public void whenGetNextStageIdForId3ShouldGetStage4()
        {
            Assert.AreEqual(4, controller.GetNextStageId(3));
        }

        [TestMethod]
        public void whenGetNextStageIdForId5ShouldGetNull()
        {
            Assert.IsNull(controller.GetNextStageId(5));
        }

    }
}
