using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Resulz.Validation.UnitTest
{
    [TestClass()]
    public class RequiredExtensionsTests
    {
        [TestMethod()]
        public void RequiredTestSuccesWithString()
        {
            var strvalue = "value";
            var result = OperationResult
                .MakeSuccess()
                .With(strvalue, nameof(strvalue)).Required()
                .Result;
            Assert.IsTrue(result.Success);            
            Assert.IsFalse(result.Errors.Any());
        }

        [TestMethod()]
        public void RequiredTestSuccesWithObject()
        {
            var objvalue = new { Name = "John", Surname = "Snow" };
            var result = OperationResult
                .MakeSuccess()
                .With(objvalue, nameof(objvalue)).Required()
                .Result;
            Assert.IsTrue(result.Success);
            Assert.IsFalse(result.Errors.Any());
        }

        [TestMethod()]
        public void RequiredTestFailWithString()
        {
            var strvalue = "";
            var result = OperationResult
                .MakeSuccess()
                .With(strvalue, nameof(strvalue)).Required()
                .Result;
            var error = ErrorMessage.Create(nameof(strvalue), string.Format("{0}_REQUIRED", nameof(strvalue).ToUpper()));
            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.Errors.Count() == 1);
            Assert.IsTrue(result.Errors.Contains(error));
        }

        [TestMethod()]
        public void RequiredTestFailWithObject()
        {
            object? objvalue = null;
            var result = OperationResult
                .MakeSuccess()
                .With(objvalue, nameof(objvalue)).Required()
                .Result;
            var error = ErrorMessage.Create(nameof(objvalue), string.Format("{0}_REQUIRED", nameof(objvalue).ToUpper()));
            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.Errors.Count() == 1);
            Assert.IsTrue(result.Errors.Contains(error));
        }
    }
}