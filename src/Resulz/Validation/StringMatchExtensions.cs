using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Resulz.Validation
{
    public static class StringMatchExtensions
    {
        public static ValueChecker<string> StringMatch(this ValueChecker<string> checker, string regEx) => StringMatch(checker, regEx, RegexOptions.None, false, string.Format("{0}_NOT_MATCHED", checker.Context).ToUpper());
        
        public static ValueChecker<string> StringMatch(this ValueChecker<string> checker, string regEx, bool allowNullOrEmpty) => StringMatch(checker, regEx, RegexOptions.None, allowNullOrEmpty, string.Format("{0}_NOT_MATCHED", checker.Context).ToUpper());
        
        public static ValueChecker<string> StringMatch(this ValueChecker<string> checker, string regEx, bool allowNullOrEmpty, RegexOptions regExOptions) => StringMatch(checker, regEx, regExOptions, allowNullOrEmpty, string.Format("{0}_NOT_MATCHED", checker.Context).ToUpper());

        public static ValueChecker<string> StringMatch(this ValueChecker<string> checker, string regEx, bool allowNullOrEmpty, string message) => StringMatch(checker, regEx, RegexOptions.None, allowNullOrEmpty, message);

        public static ValueChecker<string> StringMatch(this ValueChecker<string> checker, string regEx, RegexOptions regExOptions) => StringMatch(checker, regEx, regExOptions, false, string.Format("{0}_NOT_MATCHED", checker.Context).ToUpper());

        public static ValueChecker<string> StringMatch(this ValueChecker<string> checker, string regEx, RegexOptions regExOptions, string message) => StringMatch(checker, regEx, regExOptions, false, message);

        public static ValueChecker<string> StringMatch(this ValueChecker<string> checker, string regEx, string message) => StringMatch(checker, regEx, RegexOptions.None, false, message);        

        public static ValueChecker<string> StringMatch(this ValueChecker<string> checker, string regEx, RegexOptions regExOptions, bool allowNullOrEmpty, string message)
        {
            if (allowNullOrEmpty && string.IsNullOrEmpty(checker.Value))
            {
                return checker;
            }
            if (!Regex.IsMatch(checker.Value, regEx, regExOptions))
            {
                checker.Result.AppendError(checker.Context, message);
            }
            return checker;
        }

    }
}
