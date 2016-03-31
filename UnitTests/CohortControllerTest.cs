using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Evaluation.Controller;
using Test;
using Evaluation.Model;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class CohortControllerTest
    {
        IEvaluationController controller = new EvaluationController(new TestDAL());

        [TestMethod]
        public void whenGetCohortAddScheduleInfo1ShouldReturn2Responses()
        {
            List<CohortScheduleData> list = controller.getCohortAddScheduleInfo(1);
            Assert.AreEqual(2, list.Count);
            CohortScheduleData info = list[0];
            Assert.AreEqual(1, info.TypeId);
            Assert.IsNull(info.LastStageEndDate);
            Assert.AreEqual(1, info.NextStageId);
            info = list[1];
            Assert.AreEqual(2, info.TypeId);
            Assert.AreEqual(info.LastStageEndDate, DateTime.Parse("6/5/2016"));
            Assert.AreEqual(3, info.NextStageId);
        }

        [TestMethod]
        public void whenGetCohortAddScheduleInfo2ShouldReturn2Responses()
        {
            List<CohortScheduleData> list = controller.getCohortAddScheduleInfo(2);
            Assert.AreEqual(2, list.Count);
            CohortScheduleData info = list[0];
            Assert.AreEqual(1, info.TypeId);
            Assert.AreEqual(info.LastStageEndDate, DateTime.Parse("4/15/2016"));
            Assert.AreEqual(5, info.NextStageId);
            info = list[1];
            Assert.AreEqual(2, info.TypeId);
            Assert.AreEqual(info.LastStageEndDate, DateTime.Parse("5/25/2016"));
            Assert.IsNull(info.NextStageId);
        }

    }
}
