namespace Resulz
{
    public static class OperationResultStandardInfoCodes
    {        
        public const string NOT_FOUND = "NOT_FOUND";
        public const string NOT_AUTHORIZED = "NOT_AUTHORIZED";
        public const string NOT_VALID = "NOT_VALID";
        public const string BAD_REQUEST = "BAD_REQUEST";
        public const string GENERIC_ERROR = "GENERIC_ERROR";        

        public static OperationResult SetBadRequestCode(this OperationResult operationResult) => operationResult.SetAdditionalInfo(BAD_REQUEST);
        public static OperationResult SetNotAuthorizedCode(this OperationResult operationResult) => operationResult.SetAdditionalInfo(NOT_AUTHORIZED);
        public static OperationResult SetNotFoundCode(this OperationResult operationResult) => operationResult.SetAdditionalInfo(NOT_FOUND);
        public static OperationResult SetNotValidCode(this OperationResult operationResult) => operationResult.SetAdditionalInfo(NOT_VALID);
        public static OperationResult SetGenericErrorCode(this OperationResult operationResult) => operationResult.SetAdditionalInfo(GENERIC_ERROR);
        public static OperationResult<T> SetBadRequestCode<T>(this OperationResult<T> operationResult) => operationResult.SetAdditionalInfo(BAD_REQUEST);
        public static OperationResult<T> SetNotAuthorizedCode<T>(this OperationResult<T> operationResult) => operationResult.SetAdditionalInfo(NOT_AUTHORIZED);
        public static OperationResult<T> SetNotFoundCode<T>(this OperationResult<T> operationResult) => operationResult.SetAdditionalInfo(NOT_FOUND);
        public static OperationResult<T> SetNotValidCode<T>(this OperationResult<T> operationResult) => operationResult.SetAdditionalInfo(NOT_VALID);
        public static OperationResult<T> SetGenericErrorCode<T>(this OperationResult<T> operationResult) => operationResult.SetAdditionalInfo(GENERIC_ERROR);
    }
}
