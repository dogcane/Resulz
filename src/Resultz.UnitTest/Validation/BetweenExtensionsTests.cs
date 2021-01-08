using Microsoft.VisualStudio.TestTools.UnitTesting;
using Resulz.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Resulz.Validation.Tests
{
    [TestClass()]
    public class BetweenExtensionsTests
    {
        [TestMethod()]
        public void BetweenTestSuccessWithNumber()
        {
            var numvalue = 12;
            var result = OperationResult
                .MakeSuccess()
                .With(numvalue, nameof(numvalue)).Between(1, 20)
                .Result;
            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.Errors.Count() == 0);
        }

        [TestMethod()]
        public void BetweenTestFailWithNumber()
        {
            var numvalue = 22;
            var result = OperationResult
                .MakeSuccess()
                .With(numvalue, nameof(numvalue)).Between(1, 20)
                .Result;
            var error = ErrorMessage.Create(nameof(numvalue), string.Format("{0}_NOT_BETWEEN", nameof(numvalue).ToUpper()));
            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.Errors.Count() == 1);
            Assert.IsTrue(result.Errors.Contains(error));
        }

        [TestMethod()]
        public void BetweenTestSuccessWithDate()
        {
            var datevalue = new DateTime(2020, 1, 1);
            var result = OperationResult
                .MakeSuccess()
                .With(datevalue, nameof(datevalue)).Between(new DateTime(2019, 12, 1), new DateTime(2030, 1, 1))
                .Result;
            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.Errors.Count() == 0);
        }

        [TestMethod()]
        public void BetweenTestFailWithDate()
        {
            var datevalue = new DateTime(2020, 1, 1);
            var result = OperationResult
                .MakeSuccess()
                .With(datevalue, nameof(datevalue)).Between(new DateTime(2020, 12, 1), new DateTime(2030, 1, 1))
                .Result;
            var error = ErrorMessage.Create(nameof(datevalue), string.Format("{0}_NOT_BETWEEN", nameof(datevalue).ToUpper()));
            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.Errors.Count() == 1);
            Assert.IsTrue(result.Errors.Contains(error));
        }

        [TestMethod()]
        public void BetweenTestSuccessWithString()
        {
            var strvalue = "b";
            var result = OperationResult
                .MakeSuccess()
                .With(strvalue, nameof(strvalue)).Between("a", "c")
                .Result;
            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.Errors.Count() == 0);
        }

        [TestMethod()]
        public void BetweenTestFailWithString()
        {
            var strvalue = "z";
            var result = OperationResult
                .MakeSuccess()
                .With(strvalue, nameof(strvalue)).Between("a", "c")
                .Result;
            var error = ErrorMessage.Create(nameof(strvalue), string.Format("{0}_NOT_BETWEEN", nameof(strvalue).ToUpper()));
            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.Errors.Count() == 1);
            Assert.IsTrue(result.Errors.Contains(error));
        }

        [TestMethod()]
        public void BetweenTestFailWithNullValues()
        {
            var strvalue = "a";
            var result = OperationResult
                .MakeSuccess()
                .With(strvalue, nameof(strvalue)).Between(null, null)
                .Result;
            var error = ErrorMessage.Create(nameof(strvalue), string.Format("{0}_NOT_BETWEEN", nameof(strvalue).ToUpper()));
            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.Errors.Count() == 1);
            Assert.IsTrue(result.Errors.Contains(error));
        }

    }
}