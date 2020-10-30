using System;
using System.Collections.Generic;
using System.Text;

namespace Resulz.Validation
{
    public static class RequiredExtensions
    {
        public static ValueChecker<T> Required<T>(this ValueChecker<T> checker) => Required(checker, string.Format("{0}_REQUIRED", checker.Context).ToUpper());

        public static ValueChecker<T> Required<T>(this ValueChecker<T> checker, string message)
        {
            if (checker.Value is string && string.IsNullOrEmpty(checker.Value as string))
            {
                checker.Result.AppendError(checker.Context, message);
            }
            else if (((object)checker.Value) == null)
            {
                checker.Result.AppendError(checker.Context, message);
            }
            return checker;
        }
    }
}
