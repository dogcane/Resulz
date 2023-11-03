using System;
using System.Collections;

namespace Resulz.Validation
{
    public static class LessThenOrEqualExtensions
    {
        public static ValueChecker<T?> LessThenOrEqual<T>(this ValueChecker<T?> checker, T value) where T : IComparable<T?>
               => LessThenOrEqual(checker, value, string.Format("{0}_NOT_LESS_OR_EQUAL", checker.Context).ToUpper());

        public static ValueChecker<T?> LessThenOrEqual<T>(this ValueChecker<T?> checker, T value, string description) where T : IComparable<T?>
        {
            if (checker.CanContinue() && (checker.Value == null || value == null || (value != null && checker.Value.CompareTo(value) > 0)))
            {
                checker.Result.AppendError(checker.Context, description);
            }
            return checker;
        }
    }
}
