using System;

namespace Resulz.Validation
{
    public static class EqualToExtensions
    {
        public static ValueChecker<T> EqualTo<T>(this ValueChecker<T> checker, T value) where T : IEquatable<T>
            => EqualTo(checker, value, string.Format("{0}_NOT_EQUAL", checker.Context).ToUpper());

        public static ValueChecker<T> EqualTo<T>(this ValueChecker<T> checker, T value, string message) where T : IEquatable<T>
        {
            if (checker.CanContinue() && (!object.Equals(checker.Value, value)))
            {
                checker.Result.AppendError(checker.Context, message);
            }
            return checker;
        }

        public static ValueChecker<string> EqualTo(this ValueChecker<string> checker, string value, StringComparison comparisonType)
            => EqualTo(checker, value, string.Format("{0}_NOT_EQUAL", checker.Context).ToUpper());

        public static ValueChecker<string> EqualTo(this ValueChecker<string> checker, string value, StringComparison comparisonType, string message)
        {
            if (checker.CanContinue() && (!string.Equals(checker.Value, value, comparisonType)))
            {
                checker.Result.AppendError(checker.Context, message);
            }
            return checker;
        }
    }
}
