using Microsoft.AspNetCore.Mvc;
using System;

namespace Resulz.Web
{
    public static class OperationResultActionResultExtensions
    {
        public static IActionResult ToActionResult(this OperationResult operationResult)
        {
            if (operationResult == null)
            {
                throw new ArgumentNullException(nameof(operationResult));
            }

            if (operationResult.Success)
            {
                return new NoContentResult();
            }

            return operationResult.AdditionalInfo switch
            {
                OperationResultStandardInfoCodes.BAD_REQUEST => new BadRequestObjectResult(operationResult),
                OperationResultStandardInfoCodes.NOT_FOUND => new NotFoundObjectResult(operationResult),
                OperationResultStandardInfoCodes.NOT_AUTHORIZED => new UnauthorizedResult(),                
                OperationResultStandardInfoCodes.NOT_VALID => new UnprocessableEntityObjectResult(operationResult),
                _ => new ObjectResult(operationResult)
                {
                    StatusCode = 500
                }
            };
        }

        public static IActionResult ToActionResult<T>(this OperationResult<T> operationResult)
        {
            if (operationResult == null)
            {
                throw new ArgumentNullException(nameof(operationResult));
            }

            if (operationResult.Success)
            {
                return new OkObjectResult(operationResult.Value);
            }

            return operationResult.AdditionalInfo switch
            {
                OperationResultStandardInfoCodes.BAD_REQUEST => new BadRequestObjectResult(operationResult),
                OperationResultStandardInfoCodes.NOT_FOUND => new NotFoundObjectResult(operationResult),
                OperationResultStandardInfoCodes.NOT_AUTHORIZED => new UnauthorizedResult(),
                OperationResultStandardInfoCodes.NOT_VALID => new UnprocessableEntityObjectResult(operationResult),
                _ => new ObjectResult(operationResult)
                {
                    StatusCode = 500
                }
            };
        }
    }
}
