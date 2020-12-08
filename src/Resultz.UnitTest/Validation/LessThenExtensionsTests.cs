using Microsoft.VisualStudio.TestTools.UnitTesting;
using Resulz.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Resulz.Validation.Tests
{
    [TestClass()]
    public class LessThenExtensionsTests
    {
        [TestMethod()]
        public void LessThenTestSuccessWithNumber()
        {
            var numvalue = 12;
            var result = OperationResult
                .MakeSuccess()
                .With(numvalue, nameof(numvalue)).LessThen(20)
                .Result;
            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.Errors.Count() == 0);
        }

        [TestMethod()]
        public void LessThenTestFailWithNumber()
        {
            var numvalue = 12;
            var result = OperationResult
                .MakeSuccess()
                .With(numvalue, nameof(numvalue)).LessThen(10)
                .Result;
            var error = ErrorMessage.Create(nameof(numvalue), string.Format("{0}_NOT_LESS", nameof(numvalue).ToUpper()));
            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.Errors.Count() == 1);
            Assert.IsTrue(result.Errors.Contains(error));
        }

        [TestMethod()]
        public void LessThenTestSuccessWithDate()
        {
            var datevalue = new DateTime(2020, 1, 1);
            var result = OperationResult
                .MakeSuccess()
                .With(datevalue, nameof(datevalue)).LessThen(new DateTime(2100, 1, 1))
                .Result;
            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.Errors.Count() == 0);
        }

        [TestMethod()]
        public void LessThenTestFailWithDate()
        {
            var datevalue = new DateTime(2020, 1, 1);
            var result = OperationResult
                .MakeSuccess()
                .With(datevalue, nameof(datevalue)).LessThen(new DateTime(2000, 1, 1))
                .Result;
            var error = ErrorMessage.Create(nameof(datevalue), string.Format("{0}_NOT_LESS", nameof(datevalue).ToUpper()));
            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.Errors.Count() == 1);
            Assert.IsTrue(result.Errors.Contains(error));
        }

        [TestMethod()]
        public void LessThenTestSuccessWithString()
        {
            var strvalue = "aaaa";
            var result = OperationResult
                .MakeSuccess()
                .With(strvalue, nameof(strvalue)).LessThen("zzzz")
                .Result;
            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.Errors.Count() == 0);
        }

        [TestMethod()]
        public void LessThenTestFailWithString()
        {
            var strvalue = "zzzz";
            var result = OperationResult
                .MakeSuccess()
                .With(strvalue, nameof(strvalue)).LessThen("aaaa")
                .Result;
            var error = ErrorMessage.Create(nameof(strvalue), string.Format("{0}_NOT_LESS", nameof(strvalue).ToUpper()));
            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.Errors.Count() == 1);
            Assert.IsTrue(result.Errors.Contains(error));
        }
    }
}