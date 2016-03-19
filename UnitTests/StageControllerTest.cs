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
            Assert.IsTrue(controller.stageExists("Stage 1"));
        }

        [TestMethod]
        public void whenStageExistsStage100ShouldReturnFalse()
        {
            Assert.IsFalse(controller.stageExists("Stage 100"));
        }

        [TestMethod]
        public void whenGetStageNameForId1ShouldGetStage1()
        {
            Assert.AreEqual("Stage 1", controller.getStageName(1));
        }

        [TestMethod]
        public void whenGetStageNameForId100ShouldGetEmptyString()
        {
            Assert.AreEqual("", controller.getStageName(100));
        }

    }
}
