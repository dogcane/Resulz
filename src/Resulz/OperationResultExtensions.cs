using System;

namespace Resulz
{
    public static class OperationResultExtensions
    {
        #region IfSuccess

        public static T IfSuccess<T>(this T result, Action<T> operation)
            where T : IOperationResult
        {
            if (result == null) throw new ArgumentNullException(nameof(result));
            if (operation == null) throw new ArgumentNullException(nameof(operation));
            if (result.Success)
            {
                operation(result);
            }
            return result;
        }

        public static OperationResult<T> IfSuccessThenReturn<T>(this IOperationResult result, Func<T> factoryFunc)
        {
            if (result == null) throw new ArgumentNullException(nameof(result));
            if (factoryFunc == null) throw new ArgumentNullException(nameof(factoryFunc));
            return result.Success ? OperationResult<T>.MakeSuccess(factoryFunc()) : OperationResult<T>.MakeFailure(result.Errors);
        }

        #endregion

        #region IfFailed

        public static T IfFailed<T>(this T result, Action<T> operation)
            where T : IOperationResult
        {
            if (result == null) throw new ArgumentNullException(nameof(result));
            if (operation == null) throw new ArgumentNullException(nameof(operation));
            if (!result.Success)
            {
                operation(result);
            }
            return result;
        }

        #endregion
    }
}
