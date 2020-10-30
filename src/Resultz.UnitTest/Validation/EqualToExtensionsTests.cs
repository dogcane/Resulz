using Microsoft.VisualStudio.TestTools.UnitTesting;
using Resulz.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Resulz.Validation.UnitTest
{
    [TestClass()]
    public class EqualToExtensionsTests
    {
        [TestMethod()]
        public void EqualToTestSuccess()
        {
            var intvalue = 5;
            var result = OperationResult
                .MakeSuccess()
                .With(intvalue, nameof(intvalue)).EqualTo(5)
                .Result;
            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.Errors.Count() == 0);
        }

        [TestMethod()]
        public void EqualToTestFail()
        {
            var intvalue = 5;
            var result = OperationResult
                .MakeSuccess()
                .With(intvalue, nameof(intvalue)).EqualTo(8)
                .Result;
            var error = ErrorMessage.Create(nameof(intvalue), string.Format("{0}_NOT_EQUAL", nameof(intvalue).ToUpper()));
            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.Errors.Count() == 1);
            Assert.IsTrue(result.Errors.Contains(error));
        }

        [TestMethod()]
        public void EqualToTestSuccessWithString()
        {
            var strvalue = "value";
            var result = OperationResult
                .MakeSuccess()
                .With(strvalue, nameof(strvalue)).EqualTo("value", StringComparison.OrdinalIgnoreCase)
                .Result;
            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.Errors.Count() == 0);
        }

        [TestMethod()]
        public void EqualToTestFailWithString()
        {
            var strvalue = "value";
            var result = OperationResult
                .MakeSuccess()
                .With(strvalue, nameof(strvalue)).EqualTo("other value")
                .Result;
            var error = ErrorMessage.Create(nameof(strvalue), string.Format("{0}_NOT_EQUAL", nameof(strvalue).ToUpper()));
            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.Errors.Count() == 1);
            Assert.IsTrue(result.Errors.Contains(error));
        }
    }
}