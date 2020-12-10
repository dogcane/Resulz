using System;
using System.Collections.Generic;
using System.Text;

namespace Resulz.Validation
{
    public static class ConditionExtensions
    {
        public static ValueChecker<T> Condition<T>(this ValueChecker<T> checker, Func<T, bool> condition)
            => Condition<T>(checker, condition, string.Format("{0}_CONDITION_FAILED", checker.Context).ToUpper());        

        public static ValueChecker<T> Condition<T>(this ValueChecker<T> checker, Func<T, bool> lambda, string description)
        {
            if (!lambda.Invoke(checker.Value))
            {
                checker.Result.AppendError(checker.Context, description);
            }
            return checker;
        }
    }
}
