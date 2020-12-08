using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Resulz.Validation
{
    public static class IntoExtensions
    {
        public static ValueChecker<T> Into<T>(this ValueChecker<T> checker, T[] arguments)
            => Into<T>(checker, arguments, string.Format("{0}_NOT_INTO", checker.Context).ToUpper());

        public static ValueChecker<T> Into<T>(this ValueChecker<T> checker, T[] arguments, string description)
        {
            if (arguments.Length == 0 || !arguments.Contains(checker.Value))
            {
                checker.Result.AppendError(checker.Context, description);
            }
            return checker;
        }
    }
}
