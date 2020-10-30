using System;
using System.Collections.Generic;
using System.Text;

namespace Resulz.Validation
{
    public static class EqualToExtensions
    {
        public static ValueChecker<T> EqualTo<T>(this ValueChecker<T> checker, T value) => EqualTo(checker, value, string.Format("{0}_NOT_EQUAL", checker.Context).ToUpper());

        public static ValueChecker<T> EqualTo<T>(this ValueChecker<T> checker, T value, string message)
        {
            if ((value != null && !value.Equals(checker.Value)) || (checker.Value != null && !checker.Value.Equals(value)))
            {
                checker.Result.AppendError(checker.Context, message);
            }
            return checker;
        }

        public static ValueChecker<string> EqualTo(this ValueChecker<string> checker, string value, StringComparison comparisonType) => EqualTo(checker, value, string.Format("{0}_NOT_EQUAL", checker.Context).ToUpper());

        public static ValueChecker<string> EqualTo(this ValueChecker<string> checker, string value, StringComparison comparisonType, string message)
        {
            if ((value != null && !value.Equals(checker.Value, comparisonType)) || (checker.Value != null && !checker.Value.Equals(value, comparisonType)))
            {
                checker.Result.AppendError(checker.Context, message);
            }
            return checker;
        }
    }
}
