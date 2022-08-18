using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Resulz.Validation.UnitTest
{
    [TestClass()]
    public class LessThenOrEqualExtensionsTests
    {
        [TestMethod()]
        public void LessThenTestSuccessWithNumber()
        {
            var numvalue = 12;
            var result = OperationResult
                .MakeSuccess()
                .With(numvalue, nameof(numvalue)).LessThenOrEqual(20)
                .Result;
            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.Errors.Count() == 0);
            result = OperationResult
                .MakeSuccess()
                .With(numvalue, nameof(numvalue)).LessThenOrEqual(12)
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
                .With(numvalue, nameof(numvalue)).LessThenOrEqual(10)
                .Result;
            var error = ErrorMessage.Create(nameof(numvalue), string.Format("{0}_NOT_LESS_OR_EQUAL", nameof(numvalue).ToUpper()));
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
                .With(datevalue, nameof(datevalue)).LessThenOrEqual(new DateTime(2100, 1, 1))
                .Result;
            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.Errors.Count() == 0);
            result = OperationResult
                .MakeSuccess()
                .With(datevalue, nameof(datevalue)).LessThenOrEqual(new DateTime(2020, 1, 1))
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
                .With(datevalue, nameof(datevalue)).LessThenOrEqual(new DateTime(2000, 1, 1))
                .Result;
            var error = ErrorMessage.Create(nameof(datevalue), string.Format("{0}_NOT_LESS_OR_EQUAL", nameof(datevalue).ToUpper()));
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
                .With(strvalue, nameof(strvalue)).LessThenOrEqual("zzzz")
                .Result;
            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.Errors.Count() == 0);
            result = OperationResult
                .MakeSuccess()
                .With(strvalue, nameof(strvalue)).LessThenOrEqual("aaaa")
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
                .With(strvalue, nameof(strvalue)).LessThenOrEqual("aaaa")
                .Result;
            var error = ErrorMessage.Create(nameof(strvalue), string.Format("{0}_NOT_LESS_OR_EQUAL", nameof(strvalue).ToUpper()));
            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.Errors.Count() == 1);
            Assert.IsTrue(result.Errors.Contains(error));
        }
    }
}