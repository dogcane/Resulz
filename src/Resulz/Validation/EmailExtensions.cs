using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Resulz.Validation
{
    public static class EmailExtensions
    {
        private static readonly Regex emailRegex = new Regex(@"^(([^<>()[\]\\.,;:\s@\""]+"
            + @"(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@"
            + @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}"
            + @"\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+"
            + @"[a-zA-Z]{2,}))$", RegexOptions.Compiled);

        public static ValueChecker<string> Email(this ValueChecker<string> checker) => Email(checker, string.Format("{0}_NOT_EMAIL", checker.Context).ToUpper());

        public static ValueChecker<string> Email(this ValueChecker<string> checker, string message)
        {
            if (checker.CanContinue() && (!IsValidEmail(checker.Value ?? string.Empty)))
            {
                checker.Result.AppendError(checker.Context, message);
            }
            return checker;
        }

        private static bool IsValidEmail(string value) => emailRegex.IsMatch(value);
    }
}
