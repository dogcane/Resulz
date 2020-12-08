using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Resulz.Validation
{
    public static class LessThenExtensions
    {
        public static ValueChecker<T> LessThen<T>(this ValueChecker<T> checker, T value) where T : IComparable<T>
            => LessThen(checker, value, string.Format("{0}_NOT_LESS", checker.Context).ToUpper());

        public static ValueChecker<T> LessThen<T>(this ValueChecker<T> checker, T value, string description) where T : IComparable<T>
        {
            if (Comparer.Default.Compare(checker.Value, value) >= 0)
            {
                checker.Result.AppendError(checker.Context, description);
            }
            return checker;
        }
    }
}
