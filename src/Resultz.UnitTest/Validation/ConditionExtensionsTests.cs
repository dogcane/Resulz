using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Resulz.Validation.UnitTest
{
    [TestClass()]
    public class ConditionExtensionsTests
    {
        [TestMethod()]
        public void ConditionTestSuccess()
        {
            int numvalue = 20;
            var result = OperationResult
                .MakeSuccess()
                .With(numvalue, nameof(numvalue)).Condition(num => num > 10)
                .Result;
            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.Errors.Count() == 0);
        }

        [TestMethod()]
        public void ConditionTestFail()
        {
            int numvalue = 5;
            var result = OperationResult
                .MakeSuccess()
                .With(numvalue, nameof(numvalue)).Condition(num => num > 10)
                .Result;
            var error = ErrorMessage.Create(nameof(numvalue), string.Format("{0}_CONDITION_FAILED", nameof(numvalue).ToUpper()));
            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.Errors.Count() == 1);
            Assert.IsTrue(result.Errors.Contains(error));
        }
    }
}