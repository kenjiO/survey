using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Evaluation.Controller;
using Test;

namespace UnitTests
{
    [TestClass]
    public class TypeControllerTest
    {
        IEvaluationController controller = new EvaluationController(new TestDAL());

        [TestMethod]
        public void whenTypeExistsType1ShouldReturnTrue()
        {
            Assert.IsTrue(controller.typeExists("Type 1"));
        }

        [TestMethod]
        public void whenTypeExistsType10ShouldReturnFalse()
        {
            Assert.IsFalse(controller.typeExists("Type 10"));
        }

        [TestMethod]
        public void whenGetTypeNameForId1ShouldGetType1()
        {
            Assert.AreEqual("Type 1", controller.getTypeName(1));
        }

        [TestMethod]
        public void whenGetTypeNameForId10ShouldGetEmptyString()
        {
            Assert.AreEqual("", controller.getTypeName(10));
        }

    }
}
