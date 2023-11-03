using System;
using System.Collections;

namespace Resulz.Validation
{
    public static class GreaterThenOrEqualExtensions
    {
        public static ValueChecker<T?> GreaterThenOrEqual<T>(this ValueChecker<T?> checker, T value) where T : IComparable<T?>
            => GreaterThenOrEqual(checker, value, string.Format("{0}_NOT_GREATER_OR_EQUAL", checker.Context).ToUpper());

        public static ValueChecker<T?> GreaterThenOrEqual<T>(this ValueChecker<T?> checker, T value, string description) where T : IComparable<T?>
        {
            if (checker.CanContinue() && (checker.Value == null || value == null || (value != null && checker.Value.CompareTo(value) < 0)))
            {
                checker.Result.AppendError(checker.Context, description);
            }
            return checker;
        }
    }
}
