using Microsoft.VisualStudio.TestTools.UnitTesting;
using Resulz.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Resulz.Validation.Tests
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
    }
}