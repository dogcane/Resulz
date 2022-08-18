using System.Text.RegularExpressions;

namespace Resulz.Validation
{
    public static class StringMatchExtensions
    {
        public static ValueChecker<string> StringMatch(this ValueChecker<string> checker, string regEx) => StringMatch(checker, regEx, RegexOptions.None, string.Format("{0}_NOT_MATCHED", checker.Context).ToUpper());

        public static ValueChecker<string> StringMatch(this ValueChecker<string> checker, string regEx, RegexOptions regExOptions) => StringMatch(checker, regEx, regExOptions, string.Format("{0}_NOT_MATCHED", checker.Context).ToUpper());

        public static ValueChecker<string> StringMatch(this ValueChecker<string> checker, string regEx, string message) => StringMatch(checker, regEx, RegexOptions.None, message);

        public static ValueChecker<string> StringMatch(this ValueChecker<string> checker, string regEx, RegexOptions regExOptions, string message)
        {
            if (checker.CanContinue() && (!Regex.IsMatch(checker.Value ?? string.Empty, regEx, regExOptions)))
            {
                checker.Result.AppendError(checker.Context, message);
            }
            return checker;
        }

    }
}
