namespace Resulz.Validation.Countries;

public static class CountryValidationExtensions
{
    public static ValueChecker<string?> ValidateVatNumber(this ValueChecker<string?> checker, string country)
        => ValidateVatNumber(checker, country, string.Format("{0}_NOT_VATNUMBER", checker.Context).ToUpper());

    public static ValueChecker<string?> ValidateVatNumber(ValueChecker<string?> checker, string country, string message)
    {
        if (checker.CanContinue() && (string.IsNullOrEmpty(checker.Value) || !CountryValidator.IsVatNumberValid(checker.Value, country)))
        {
            checker.Result.AppendError(checker.Context, message);
        }
        return checker;
    }

    public static ValueChecker<string?> ValidateVatRecipientCode(this ValueChecker<string?> checker, string country)
        => ValidateVatRecipientCode(checker, country, string.Format("{0}_NOT_VATRECIPIENTCODE", checker.Context).ToUpper());

    public static ValueChecker<string?> ValidateVatRecipientCode(this ValueChecker<string?> checker, string country, string message)
    {
        if (checker.CanContinue() && (string.IsNullOrEmpty(checker.Value) || !CountryValidator.IsVatRecipientCodeValid(checker.Value, country)))
        {
            checker.Result.AppendError(checker.Context, message);
        }
        return checker;
    }
}
