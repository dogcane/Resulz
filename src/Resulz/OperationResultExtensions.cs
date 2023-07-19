using System;
using System.Linq;

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

        public static bool HasErrors(this IOperationResult result, string context, string description)
        {
            if (result == null) throw new ArgumentNullException(nameof(result));
            if (context == null) throw new ArgumentNullException(nameof(context));
            if (description == null) throw new ArgumentNullException(nameof(description));
            return result.Errors.Any(e => string.Equals(e.Context, context, StringComparison.CurrentCultureIgnoreCase) && string.Equals(e.Description, description, StringComparison.CurrentCultureIgnoreCase));
        }

        public static bool HasErrorsByContext(this IOperationResult result, string context)
        {
            if (result == null) throw new ArgumentNullException(nameof(result));
            if (context == null) throw new ArgumentNullException(nameof(context));
            return result.Errors.Any(e => string.Equals(e.Context, context, StringComparison.CurrentCultureIgnoreCase));
        }

        public static bool HasErrorsByDescription(this IOperationResult result, string description)
        {
            if (result == null) throw new ArgumentNullException(nameof(result));
            if (description == null) throw new ArgumentNullException(nameof(description));
            return result.Errors.Any(e => string.Equals(e.Description, description, StringComparison.CurrentCultureIgnoreCase));
        }        

        #endregion
    }
}
