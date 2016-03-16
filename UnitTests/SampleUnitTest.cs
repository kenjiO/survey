using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Evaluation.Model;
using Test;

namespace UnitTests
{
    /// <summary>
    /// Testing TestController to get unit tests started
    /// </summary>
    [TestClass]
    public class TestControllerTest
    {
        TestController controller = new TestController();

        [TestMethod]
        public void whenGetStageListShouldHave5Stages()
        {
            List<Stage> list = controller.getStageList();
            Assert.AreEqual(5, list.Count);
        }

        [TestMethod]
        public void whenGetTypeNameShouldGiveType1()
        {
            Assert.AreEqual("Type 1", controller.getTypeName(1));
        }

        [TestMethod]
        public void whenGetTypeNameShouldGiveType2()
        {
            Assert.AreEqual("Type 2", controller.getTypeName(2));
        }

        [TestMethod]
        public void whenGetEvaluationScheduleListShouldHave2EvaluationsForCohort1()
        {
            List<EvaluationSchedule> list = controller.getEvaluationScheduleList(1);
            Assert.AreEqual(2, list.Count);
        }

        [TestMethod]
        public void whenGetEvaluationScheduleListShouldHave2EvaluationsForCohort2()
        {
            List<EvaluationSchedule> list = controller.getEvaluationScheduleList(2);
            Assert.AreEqual(1, list.Count);
        }
    }
}
