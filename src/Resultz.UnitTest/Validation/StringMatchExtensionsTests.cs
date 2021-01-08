using Microsoft.VisualStudio.TestTools.UnitTesting;
using Resulz.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Resulz.Validation.Tests
{
    [TestClass()]
    public class StringMatchExtensionsTests
    {
        [TestMethod()]
        public void StringMatchTestSucces()
        {
            var strvalue = "value";
            var result = OperationResult
                .MakeSuccess()
                .With(strvalue, nameof(strvalue)).StringMatch("va\\w+e", RegexOptions.Compiled)
                .Result;
            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.Errors.Count() == 0);
        }

        [TestMethod()]
        public void StringMatchTestFail()
        {
            var strvalue = "value";
            var result = OperationResult
                .MakeSuccess()
                .With(strvalue, nameof(strvalue)).StringMatch("\\d+\\w+", RegexOptions.Compiled)
                .Result;
            var error = ErrorMessage.Create(nameof(strvalue), string.Format("{0}_NOT_MATCHED", nameof(strvalue).ToUpper()));
            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.Errors.Count() == 1);
            Assert.IsTrue(result.Errors.Contains(error));
        }

        public void StringMatchTestFailWithEmptyValue()
        {
            var strvalue = string.Empty;
            var result = OperationResult
                .MakeSuccess()
                .With(strvalue, nameof(strvalue)).StringMatch("va\\w+e", RegexOptions.Compiled)
                .Result;
            var error = ErrorMessage.Create(nameof(strvalue), string.Format("{0}_NOT_MATCHED", nameof(strvalue).ToUpper()));
            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.Errors.Count() == 1);
            Assert.IsTrue(result.Errors.Contains(error));
        }

        public void StringMatchTestFailWithNullValue()
        {
            string strvalue = null;
            var result = OperationResult
                .MakeSuccess()
                .With(strvalue, nameof(strvalue)).StringMatch("va\\w+e", RegexOptions.Compiled)
                .Result;
            var error = ErrorMessage.Create(nameof(strvalue), string.Format("{0}_NOT_MATCHED", nameof(strvalue).ToUpper()));
            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.Errors.Count() == 1);
            Assert.IsTrue(result.Errors.Contains(error));
        }
    }
}