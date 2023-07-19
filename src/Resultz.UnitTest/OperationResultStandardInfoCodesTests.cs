using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Resulz.UnitTest
{
    [TestClass()]
    public class OperationResultStandardInfoCodesTests
    {
        [TestMethod()]
        public void SetBadRequestCodeTest()
        {
            OperationResult result = OperationResult.MakeFailure(ErrorMessage.Create("BAD_REQUEST"));
            result.SetBadRequestCode();
            Assert.AreEqual("BAD_REQUEST", result.AdditionalInfo);
        }

        [TestMethod()]
        public void SetNotAuthorizedCodeTest()
        {
            OperationResult result = OperationResult.MakeFailure(ErrorMessage.Create("NOT_AUTHORIZED"));
            result.SetNotAuthorizedCode();
            Assert.AreEqual("NOT_AUTHORIZED", result.AdditionalInfo);                        
        }

        [TestMethod()]
        public void SetNotFoundCodeTest()
        {
            OperationResult result = OperationResult.MakeFailure(ErrorMessage.Create("NOT_FOUND"));
            result.SetNotFoundCode();
            Assert.AreEqual("NOT_FOUND", result.AdditionalInfo);
        }

        [TestMethod()]
        public void SetNotValidCodeTest()
        {
            OperationResult result = OperationResult.MakeFailure(ErrorMessage.Create("NOT_VALID"));
            result.SetNotValidCode();
            Assert.AreEqual("NOT_VALID", result.AdditionalInfo);
        }

        [TestMethod()]
        public void SetGenericErrorCodeTest()
        {
            OperationResult result = OperationResult.MakeFailure(ErrorMessage.Create("GENERIC_ERROR"));
            result.SetGenericErrorCode();
            Assert.AreEqual("GENERIC_ERROR", result.AdditionalInfo);
        }

        [TestMethod()]
        public void SetBadRequestCodeOfTTest()
        {
            OperationResult<int> result = OperationResult<int>.MakeFailure(ErrorMessage.Create("BAD_REQUEST"));
            result.SetBadRequestCode();
            Assert.AreEqual("BAD_REQUEST", result.AdditionalInfo);
        }

        [TestMethod()]
        public void SetNotAuthorizedOfTCodeTest()
        {
            OperationResult<int> result = OperationResult<int>.MakeFailure(ErrorMessage.Create("NOT_AUTHORIZED"));
            result.SetNotAuthorizedCode();
            Assert.AreEqual("NOT_AUTHORIZED", result.AdditionalInfo);
        }

        [TestMethod()]
        public void SetNotFoundCodeOfTTest()
        {
            OperationResult<int> result = OperationResult<int>.MakeFailure(ErrorMessage.Create("NOT_FOUND"));
            result.SetNotFoundCode();
            Assert.AreEqual("NOT_FOUND", result.AdditionalInfo);
        }

        [TestMethod()]
        public void SetNotValidCodeOfTTest()
        {
            OperationResult<int> result = OperationResult<int>.MakeFailure(ErrorMessage.Create("NOT_VALID"));
            result.SetNotValidCode();
            Assert.AreEqual("NOT_VALID", result.AdditionalInfo);
        }

        [TestMethod()]
        public void SetGenericErrorCodeOdTTest()
        {
            OperationResult<int> result = OperationResult<int>.MakeFailure(ErrorMessage.Create("GENERIC_ERROR"));
            result.SetGenericErrorCode();
            Assert.AreEqual("GENERIC_ERROR", result.AdditionalInfo);
        }
    }
}