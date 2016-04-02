using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Evaluation.Controller;
using Test;
using Evaluation.Model;

namespace UnitTests
{
    [TestClass]
    public class ScheduleControllerTest
    {
        IEvaluationController controller = new EvaluationController(new TestDAL());

        [TestMethod]
        public void whenGetStage1DatesShouldBeOpenStartSetEnd()
        {
            DateRange range = controller.GetScheduleDateRange(1, 1, 1);

            Assert.AreEqual(range.StartDate, DateTime.Parse("2000-01-01"));
            Assert.AreEqual(range.EndDate,   DateTime.Parse("2016-02-29"));
        }

        [TestMethod]
        public void whenGetStage2DatesShouldBeSetStartSetEnd()
        {
            DateRange range = controller.GetScheduleDateRange(1, 1, 2);

            Assert.AreEqual(range.StartDate, DateTime.Parse("2016-01-21"));
            Assert.AreEqual(range.EndDate, DateTime.Parse("2016-05-31"));
        }

        [TestMethod]
        public void whenGetStage3DatesShouldBeSetStartOpenEnd()
        {
            DateRange range = controller.GetScheduleDateRange(1, 1, 3);

            Assert.AreEqual(range.StartDate, DateTime.Parse("2016-03-11"));
            Assert.AreEqual(range.EndDate, DateTime.Parse("2100-12-31"));
        }

    }
}
