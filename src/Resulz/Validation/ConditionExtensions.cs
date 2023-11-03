using System;

namespace Resulz.Validation
{
    public static class ConditionExtensions
    {
        public static ValueChecker<T?> Condition<T>(this ValueChecker<T?> checker, Func<T?, bool> validCondition)
            => Condition<T?>(checker, validCondition, string.Format("{0}_CONDITION_FAILED", checker.Context).ToUpper());

        public static ValueChecker<T?> Condition<T>(this ValueChecker<T?> checker, Func<T?, bool> validCondition, string description)
        {
            if (checker.CanContinue() && (validCondition != null && !validCondition.Invoke(checker.Value)))
            {
                checker.Result.AppendError(checker.Context, description);
            }
            return checker;
        }
    }
}
