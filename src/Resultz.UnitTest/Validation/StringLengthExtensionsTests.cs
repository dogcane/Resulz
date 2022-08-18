using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Resulz.Validation.UnitTest
{
    [TestClass()]
    public class StringLengthExtensionsTests
    {

        [TestMethod()]
        public void StringLengthTestSuccess()
        {
            var strvalue = "value";
            var result = OperationResult
                .MakeSuccess()
                .With(strvalue, nameof(strvalue)).StringLength(10)
                .Result;
            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.Errors.Count() == 0);
        }

        [TestMethod()]
        public void StringLengthTestFail()
        {
            var strvalue = "a really long value";
            var result = OperationResult
                .MakeSuccess()
                .With(strvalue, nameof(strvalue)).StringLength(10)
                .Result;
            var error = ErrorMessage.Create(nameof(strvalue), string.Format("{0}_TOO_LONG", nameof(strvalue).ToUpper()));
            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.Errors.Count() == 1);
            Assert.IsTrue(result.Errors.Contains(error));
        }
    }
}