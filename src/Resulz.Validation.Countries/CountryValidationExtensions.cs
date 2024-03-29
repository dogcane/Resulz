﻿namespace Resulz.Validation.Countries;

public static class CountryValidationExtensions
{
    public static ValueChecker<string?> ValidateVatNumber(this ValueChecker<string?> checker, string country)
        => ValidateVatNumber(checker, country, string.Format("{0}_NOT_VATNUMBER", checker.Context).ToUpper());

    public static ValueChecker<string?> ValidateVatNumber(ValueChecker<string?> checker, string country, string message)
    {
        if (checker.CanContinue() && !CountryValidator.IsVatNumberValid(country, checker.Value.CountrySafeVatNumber(country) ?? ""))
        {
            checker.Result.AppendError(checker.Context, message);
        }
        return checker;
    }

    public static ValueChecker<string?> ValidateVatRecipientCode(this ValueChecker<string?> checker, string country)
        => ValidateVatRecipientCode(checker, country, string.Format("{0}_NOT_VATRECIPIENTCODE", checker.Context).ToUpper());

    public static ValueChecker<string?> ValidateVatRecipientCode(this ValueChecker<string?> checker, string country, string message)
    {
        if (checker.CanContinue() && !CountryValidator.IsVatRecipientCodeValid(country, checker.Value ?? ""))
        {
            checker.Result.AppendError(checker.Context, message);
        }
        return checker;
    }

    public static string CountrySafeVatNumber(this string? vatNumber, string country) => string.IsNullOrEmpty(vatNumber) ? "" : vatNumber!.StartsWith(country.ToUpper()) ? vatNumber : string.Format("{0}{1}", country.ToUpper(), vatNumber);
}
