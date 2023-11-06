using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Resulz.Validation.UnitTest
{
    [TestClass()]
    public class ValueCheckerTests
    {
        [TestMethod()]
        public void ValueCheckerTest()
        {
            var result = OperationResult.MakeSuccess();
            var strval = "hello";
            var checker = new ValueChecker<string?>(strval, result, nameof(strval));
            var resultNew = (OperationResult)checker;
            Assert.AreEqual(result, checker.Result);
            Assert.AreEqual(result, resultNew);
            Assert.AreEqual(strval, checker.Value);
            Assert.IsTrue(checker.CanContinue());
        }

        //[TestMethod()]
        //public void ForTest()
        //{
        //    Assert.Fail();
        //}

        [TestMethod()]
        public void StopOnErrorTest()
        {
            var result = OperationResult.MakeSuccess();
            var strval = "hello";
            var checker = new ValueChecker<string>(strval, result, nameof(strval));
            Assert.IsTrue(checker.ContinueOnError);
            checker.StopOnError();
            Assert.IsFalse(checker.ContinueOnError);
        }

        [TestMethod()]
        public void CanContinueTest()
        {
            var result = OperationResult.MakeSuccess();
            var strval = "hello";
            var checker = new ValueChecker<string?>(strval, result, nameof(strval));
            Assert.IsTrue(checker.CanContinue());
            checker.StopOnError();
            Assert.IsTrue(checker.CanContinue());
            checker.StringLength(2);
            Assert.IsFalse(checker.CanContinue());
        }

        [TestMethod()]
        public void CanContinueTestWithChain()
        {
            var result = OperationResult.MakeSuccess();
            string? strval = null;
            var checker = new ValueChecker<string?>(strval, result, nameof(strval))
                .StopOnError()
                .Required()
                .Condition(val => val?.Contains("hello") ?? false);
            Assert.IsFalse(checker.CanContinue());
            Assert.IsFalse(checker.Result.Success);
        }
    }
}