namespace Resulz.Validation
{
    public static class WithExtensions
    {
        public static ValueChecker<T?> With<T>(this OperationResult result, T? value, string context) => new(value, result, context);

        public static ValueChecker<T?> With<T, K>(this ValueChecker<K> checker, T? value, string context) => new(value, checker.Result, context);
    }
}
