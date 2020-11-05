using Microsoft.VisualStudio.TestTools.UnitTesting;
using Resulz.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Resulz.Validation.Tests
{
    [TestClass()]
    public class GreaterThenOrEqualExtensionsTests
    {
        [TestMethod()]
        public void GreaterThenOrEqualTestSuccessWithNumber()
        {
            var numvalue = 12;
            var result = OperationResult
                .MakeSuccess()
                .With(numvalue, nameof(numvalue)).GreaterThenOrEqual(10)
                .Result;
            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.Errors.Count() == 0);
            result = OperationResult
                .MakeSuccess()
                .With(numvalue, nameof(numvalue)).GreaterThenOrEqual(12)
                .Result;
            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.Errors.Count() == 0);
        }

        [TestMethod()]
        public void GreaterThenOrEqualTestFailWithNumber()
        {
            var numvalue = 12;
            var result = OperationResult
                .MakeSuccess()
                .With(numvalue, nameof(numvalue)).GreaterThenOrEqual(30)
                .Result;
            var error = ErrorMessage.Create(nameof(numvalue), string.Format("{0}_NOT_GREATER", nameof(numvalue).ToUpper()));
            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.Errors.Count() == 1);
            Assert.IsTrue(result.Errors.Contains(error));
        }

        [TestMethod()]
        public void GreaterThenOrEqualTestSuccessWithDate()
        {
            Assert.Fail();

            var datevalue = new DateTime(2020, 1, 1);
            var result = OperationResult
                .MakeSuccess()
                .With(datevalue, nameof(datevalue)).GreaterThenOrEqual(new DateTime(1900, 1, 1))
                .Result;
            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.Errors.Count() == 0);
        }

        [TestMethod()]
        public void GreaterThenOrEqualTestFailWithDate()
        {
            Assert.Fail();

            var datevalue = new DateTime(2020, 1, 1);
            var result = OperationResult
                .MakeSuccess()
                .With(datevalue, nameof(datevalue)).GreaterThenOrEqual(new DateTime(2100, 1, 1))
                .Result;
            var error = ErrorMessage.Create(nameof(datevalue), string.Format("{0}_NOT_GREATER", nameof(datevalue).ToUpper()));
            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.Errors.Count() == 1);
            Assert.IsTrue(result.Errors.Contains(error));
        }

        [TestMethod()]
        public void GreaterThenOrEqualTestSuccessWithString()
        {
            Assert.Fail();

            var strvalue = "zzzz";
            var result = OperationResult
                .MakeSuccess()
                .With(strvalue, nameof(strvalue)).GreaterThenOrEqual("aaaa")
                .Result;
            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.Errors.Count() == 0);
        }

        [TestMethod()]
        public void GreaterThenOrEqualTestFailWithString()
        {
            Assert.Fail();

            var strvalue = "aaaa";
            var result = OperationResult
                .MakeSuccess()
                .With(strvalue, nameof(strvalue)).GreaterThenOrEqual("cccc")
                .Result;
            var error = ErrorMessage.Create(nameof(strvalue), string.Format("{0}_NOT_GREATER", nameof(strvalue).ToUpper()));
            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.Errors.Count() == 1);
            Assert.IsTrue(result.Errors.Contains(error));
        }
    }
}