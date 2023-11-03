namespace Resulz.Validation
{
    public static class RequiredExtensions
    {
        public static ValueChecker<T?> Required<T>(this ValueChecker<T?> checker)
            => Required(checker, string.Format("{0}_REQUIRED", checker.Context).ToUpper());

        public static ValueChecker<T?> Required<T>(this ValueChecker<T?> checker, string message)
        {
            if (checker.CanContinue() && (checker.Value is null))
            {
                checker.Result.AppendError(checker.Context, message);
            }
            return checker;
        }

        public static ValueChecker<string?> Required(this ValueChecker<string?> checker)
            => Required(checker, string.Format("{0}_REQUIRED", checker.Context).ToUpper());

        public static ValueChecker<string?> Required(this ValueChecker<string?> checker, string message)
        {
            if (checker.CanContinue() && (string.IsNullOrEmpty(checker.Value as string)))
            {
                checker.Result.AppendError(checker.Context, message);
            }
            return checker;
        }
    }
}
