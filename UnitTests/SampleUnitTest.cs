using System;
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
    }
}
