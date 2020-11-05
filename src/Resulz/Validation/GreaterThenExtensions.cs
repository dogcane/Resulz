using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Resulz.Validation
{
    public static class GreaterThenExtensions
    {
        public static ValueChecker<T> GreaterThen<T>(this ValueChecker<T> checker, T value) where T : IComparable<T>
            => GreaterThen(checker, value, string.Format("{0}_NOT_GREATER", checker.Context).ToUpper());

        public static ValueChecker<T> GreaterThen<T>(this ValueChecker<T> checker, T value, string description) where T : IComparable<T>
        {
            if (Comparer.Default.Compare(checker.Value, value) <= 0)
            {
                checker.Result.AppendError(checker.Context, description);
            }
            return checker;
        }
    }
}
