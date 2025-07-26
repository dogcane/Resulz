using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Resulz
{
    public static class OperationResultExtensions
    {
        #region IfSuccess

        public static T IfSuccess<T>(this T result, Action<T> operation)
            where T : IOperationResult
        {
            ArgumentNullException.ThrowIfNull(result);
            ArgumentNullException.ThrowIfNull(operation);
            if (result.Success)
            {
                operation(result);
            }
            return result;
        }

        public static OperationResult<T> IfSuccessThenReturn<T>(this IOperationResult result, Func<T> factoryFunc)
        {
            ArgumentNullException.ThrowIfNull(result);
            ArgumentNullException.ThrowIfNull(factoryFunc);
            return result.Success ? OperationResult<T>.MakeSuccess(factoryFunc()) : OperationResult<T>.MakeFailure(result.Errors);
        }

        #endregion

        #region IfFailed

        public static T IfFailed<T>(this T result, Action<T> operation)
            where T : IOperationResult
        {
            ArgumentNullException.ThrowIfNull(result);
            ArgumentNullException.ThrowIfNull(operation);
            if (!result.Success)
            {
                operation(result);
            }
            return result;
        }

        #endregion

        #region Then

        public static T Then<T>(this T result, Func<T> operation)
            where T : IOperationResult
        {
            ArgumentNullException.ThrowIfNull(result);
            ArgumentNullException.ThrowIfNull(operation);
            return result.Success ? operation() : result;
        }

        public static OperationResult<T> Then<T>(this IOperationResult result, Func<OperationResult<T>> operation)
        {
            ArgumentNullException.ThrowIfNull(result);
            ArgumentNullException.ThrowIfNull(operation);
            return result.Success ? operation() : OperationResult<T>.MakeFailure(result.Errors);
        }

        #endregion

        #region HasErrors***

        public static bool HasErrors(this IOperationResult result, string context, string description)
        {
            ArgumentNullException.ThrowIfNull(result, nameof(result));
            ArgumentNullException.ThrowIfNull(context, nameof(context));
            ArgumentNullException.ThrowIfNull(description, nameof(description));
            return result.Errors.Any(e => string.Equals(e.Context, context, StringComparison.CurrentCultureIgnoreCase) && string.Equals(e.Description, description, StringComparison.CurrentCultureIgnoreCase));
        }

        public static bool HasErrorsByContext(this IOperationResult result, string context)
        {
            ArgumentNullException.ThrowIfNull(result, nameof(result));
            ArgumentNullException.ThrowIfNull(context, nameof(context));
            return result.Errors.Any(e => string.Equals(e.Context, context, StringComparison.CurrentCultureIgnoreCase));
        }

        public static bool HasErrorsByDescription(this IOperationResult result, string description)
        {
            ArgumentNullException.ThrowIfNull(result, nameof(result));
            ArgumentNullException.ThrowIfNull(description, nameof(description));
            return result.Errors.Any(e => string.Equals(e.Description, description, StringComparison.CurrentCultureIgnoreCase));
        }        

        #endregion
    }
}
