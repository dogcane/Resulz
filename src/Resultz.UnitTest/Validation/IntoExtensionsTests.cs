using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Resulz.Validation.UnitTest
{
    [TestClass()]
    public class IntoExtensionsTests
    {
        [TestMethod()]
        public void IntoTestSuccess()
        {
            var numvalue = 5;
            var arrvalue = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var result = OperationResult
                .MakeSuccess()
                .With(numvalue, nameof(numvalue)).Into(arrvalue)
                .Result;
            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.Errors.Count() == 0);
        }

        [TestMethod()]
        public void IntoTestFail()
        {
            var numvalue = 15;
            var arrvalue = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var result = OperationResult
                .MakeSuccess()
                .With(numvalue, nameof(numvalue)).Into(arrvalue)
                .Result;
            var error = ErrorMessage.Create(nameof(numvalue), string.Format("{0}_NOT_INTO", nameof(numvalue).ToUpper()));
            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.Errors.Count() == 1);
            Assert.IsTrue(result.Errors.Contains(error));
        }

        [TestMethod()]
        [DataRow("hallo")]
        [DataRow("hey")]
        [DataRow(null)]
        public void IntoTestNullSuccess(string? strvalue)
        {
            var arrvalue = new string?[] { "hallo", "hey", null };
            var result = OperationResult
                .MakeSuccess()
                .With(strvalue, nameof(strvalue)).Into(arrvalue)
                .Result;
            var error = ErrorMessage.Create(nameof(strvalue), string.Format("{0}_NOT_INTO", nameof(strvalue).ToUpper()));
            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.Errors.Count() == 0);
        }

        [TestMethod()]
        [DataRow("bye")]
        [DataRow(null)]
        public void IntoTestNullFail(string? strvalue)
        {
            var arrvalue = new string?[] { "hallo", "hey" };
            var result = OperationResult
                .MakeSuccess()
                .With(strvalue, nameof(strvalue)).Into(arrvalue)
                .Result;
            var error = ErrorMessage.Create(nameof(strvalue), string.Format("{0}_NOT_INTO", nameof(strvalue).ToUpper()));
            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.Errors.Count() == 1);
            Assert.IsTrue(result.Errors.Contains(error));
        }
    }
}