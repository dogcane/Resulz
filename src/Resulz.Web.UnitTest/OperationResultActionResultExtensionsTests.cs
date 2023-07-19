using Microsoft.AspNetCore.Mvc;

namespace Resulz.Web.UnitTest
{
    [TestClass()]
    public class OperationResultActionResultExtensionsTests
    {
        [TestMethod()]
        public void ToActionResult_SUCCESS_Test()
        {
            OperationResult result = OperationResult.MakeSuccess();
            var actionResult = result.ToActionResult();
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult));
        }

        [TestMethod()]
        public void ToActionResult_NOT_FOUND_Test()
        {
            OperationResult result = OperationResult.MakeFailure(ErrorMessage.Create("NOT_FOUND"));
            result.SetNotFoundCode();
            var actionResult = result.ToActionResult();
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundObjectResult));
        }

        [TestMethod()]
        public void ToActionResult_NOT_AUTHORIZED_Test()
        {
            OperationResult result = OperationResult.MakeFailure(ErrorMessage.Create("NOT_AUTHORIZED"));
            result.SetNotAuthorizedCode();
            var actionResult = result.ToActionResult();
            Assert.IsInstanceOfType(actionResult, typeof(UnauthorizedResult));
        }

        [TestMethod()]
        public void ToActionResult_BAD_REQUEST_Test()
        {
            OperationResult result = OperationResult.MakeFailure(ErrorMessage.Create("BAD_REQUEST"));
            result.SetBadRequestCode();
            var actionResult = result.ToActionResult();
            Assert.IsInstanceOfType(actionResult, typeof(BadRequestObjectResult));
        }

        [TestMethod()]
        public void ToActionResult_NOT_VALID_Test()
        {
            OperationResult result = OperationResult.MakeFailure(ErrorMessage.Create("NOT_VALID"));
            result.SetNotValidCode();
            var actionResult = result.ToActionResult();
            Assert.IsInstanceOfType(actionResult, typeof(UnprocessableEntityObjectResult));
        }

        [TestMethod()]
        public void ToActionResult_GENERIC_ERROR_Test()
        {
            OperationResult result = OperationResult.MakeFailure(ErrorMessage.Create("GENERIC_ERROR"));
            result.SetGenericErrorCode();
            var actionResult = result.ToActionResult();
            Assert.IsInstanceOfType(actionResult, typeof(ObjectResult));
            Assert.AreEqual(500, (actionResult as ObjectResult)?.StatusCode);
        }

        [TestMethod()]
        public void ToActionResultOfT_SUCCESS_Test()
        {
            OperationResult<int> result = OperationResult<int>.MakeSuccess(1);
            var actionResult = result.ToActionResult();
            Assert.IsInstanceOfType(actionResult, typeof(OkObjectResult));
            Assert.AreEqual(1, (actionResult as OkObjectResult)?.Value);
        }

        [TestMethod()]
        public void ToActionResultOfT_NOT_FOUND_Test()
        {
            OperationResult<int> result = OperationResult<int>.MakeFailure(ErrorMessage.Create("NOT_FOUND"));
            result.SetNotFoundCode();
            var actionResult = result.ToActionResult();
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundObjectResult));
        }

        [TestMethod()]
        public void ToActionResultOfT_NOT_AUTHORIZED_Test()
        {
            OperationResult<int> result = OperationResult<int>.MakeFailure(ErrorMessage.Create("NOT_AUTHORIZED"));
            result.SetNotAuthorizedCode();
            var actionResult = result.ToActionResult();
            Assert.IsInstanceOfType(actionResult, typeof(UnauthorizedResult));
        }

        [TestMethod()]
        public void ToActionResultOfT_BAD_REQUEST_Test()
        {
            OperationResult<int> result = OperationResult<int>.MakeFailure(ErrorMessage.Create("BAD_REQUEST"));
            result.SetBadRequestCode();
            var actionResult = result.ToActionResult();
            Assert.IsInstanceOfType(actionResult, typeof(BadRequestObjectResult));
        }

        [TestMethod()]
        public void ToActionResultOfT_NOT_VALID_Test()
        {
            OperationResult<int> result = OperationResult<int>.MakeFailure(ErrorMessage.Create("NOT_VALID"));
            result.SetNotValidCode();
            var actionResult = result.ToActionResult();
            Assert.IsInstanceOfType(actionResult, typeof(UnprocessableEntityObjectResult));
        }

        [TestMethod()]
        public void ToActionResultOfT_GENERIC_ERROR_Test()
        {
            OperationResult<int> result = OperationResult<int>.MakeFailure(ErrorMessage.Create("GENERIC_ERROR"));
            result.SetGenericErrorCode();
            var actionResult = result.ToActionResult();
            Assert.IsInstanceOfType(actionResult, typeof(ObjectResult));
            Assert.AreEqual(500, (actionResult as ObjectResult)?.StatusCode);
        }
    }
}