using System;
using System.Collections;

namespace Resulz.Validation
{
    public static class BetweenExtensions
    {
        public static ValueChecker<T?> Between<T>(this ValueChecker<T?> checker, T? firstValue, T? secondValue) where T : IComparable<T>
            => Between(checker, firstValue, secondValue, string.Format("{0}_NOT_BETWEEN", checker.Context).ToUpper());

        public static ValueChecker<T?> Between<T>(this ValueChecker<T?> checker, T? firstValue, T? secondValue, string description) where T : IComparable<T>
        {
            if (checker.CanContinue() && ((checker.Value == null || firstValue == null || secondValue == null || (firstValue != null && checker.Value.CompareTo(firstValue) <= 0) || (secondValue != null && checker.Value.CompareTo(secondValue) >= 0))))
            {
                checker.Result.AppendError(checker.Context, description);
            }
            return checker;
        }
    }
}
