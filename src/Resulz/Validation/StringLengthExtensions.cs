namespace Resulz.Validation
{
    public static class StringLengthExtensions
    {
        public static ValueChecker<string> StringLength(this ValueChecker<string> checker, int maxLength) => StringLength(checker, maxLength, string.Format("{0}_TOO_LONG", checker.Context).ToUpper());

        public static ValueChecker<string> StringLength(this ValueChecker<string> checker, int maxLength, string message)
        {
            if (checker.CanContinue() && (checker.Value != null && checker.Value.Length > maxLength))
            {
                checker.Result.AppendError(checker.Context, message);
            }
            return checker;
        }
    }
}
