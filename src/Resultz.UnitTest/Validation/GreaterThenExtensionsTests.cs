using Microsoft.VisualStudio.TestTools.UnitTesting;
using Resulz.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Resulz.Validation.Tests
{
    [TestClass()]
    public class GreaterThenExtensionsTests
    {
        [TestMethod()]
        public void GreaterThenTestSuccessWithNumber()
        {
            var numvalue = 12;
            var result = OperationResult
                .MakeSuccess()
                .With(numvalue, nameof(numvalue)).GreaterThen(10)
                .Result;
            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.Errors.Count() == 0);
        }

        [TestMethod()]
        public void GreaterThenTestFailWithNumber()
        {
            var numvalue = 12;
            var result = OperationResult
                .MakeSuccess()
                .With(numvalue, nameof(numvalue)).GreaterThen(30)
                .Result;
            var error = ErrorMessage.Create(nameof(numvalue), string.Format("{0}_NOT_GREATER", nameof(numvalue).ToUpper()));
            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.Errors.Count() == 1);
            Assert.IsTrue(result.Errors.Contains(error));
        }

        [TestMethod()]
        public void GreaterThenTestSuccessWithDate()
        {
            var datevalue = new DateTime(2020, 1, 1);
            var result = OperationResult
                .MakeSuccess()
                .With(datevalue, nameof(datevalue)).GreaterThen(new DateTime(1900,1,1))
                .Result;
            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.Errors.Count() == 0);
        }

        [TestMethod()]
        public void GreaterThenTestFailWithDate()
        {
            var datevalue = new DateTime(2020, 1, 1);
            var result = OperationResult
                .MakeSuccess()
                .With(datevalue, nameof(datevalue)).GreaterThen(new DateTime(2100, 1, 1))
                .Result;
            var error = ErrorMessage.Create(nameof(datevalue), string.Format("{0}_NOT_GREATER", nameof(datevalue).ToUpper()));
            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.Errors.Count() == 1);
            Assert.IsTrue(result.Errors.Contains(error));
        }

        [TestMethod()]
        public void GreaterThenTestSuccessWithString()
        {
            var strvalue = "zzzz";
            var result = OperationResult
                .MakeSuccess()
                .With(strvalue, nameof(strvalue)).GreaterThen("aaaa")
                .Result;
            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.Errors.Count() == 0);
        }

        [TestMethod()]
        public void GreaterThenTestFailWithString()
        {
            var strvalue = "aaaa";
            var result = OperationResult
                .MakeSuccess()
                .With(strvalue, nameof(strvalue)).GreaterThen("cccc")
                .Result;
            var error = ErrorMessage.Create(nameof(strvalue), string.Format("{0}_NOT_GREATER", nameof(strvalue).ToUpper()));
            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.Errors.Count() == 1);
            Assert.IsTrue(result.Errors.Contains(error));
        }
    }
}