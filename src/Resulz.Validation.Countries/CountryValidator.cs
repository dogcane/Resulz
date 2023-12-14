using Resulz.Validation.Countries.Validators;

namespace Resulz.Validation.Countries;

public static class CountryValidator
{
    #region Methods
    public static ICountryContextValidator GetValidator(string countryCode) => countryCode.ToUpper() switch
    {
        "AT" => new AT_CountryContextValidator(),
        "BE" => new BE_CountryContextValidator(),
        "BG" => new BG_CountryContextValidator(),
        "CY" => new CY_CountryContextValidator(),
        "CZ" => new CZ_CountryContextValidator(),
        "DE" => new DE_CountryContextValidator(),
        "DK" => new DK_CountryContextValidator(),
        "EE" => new EE_CountryContextValidator(),
        "EL" => new EL_CountryContextValidator(),
        "ES" => new ES_CountryContextValidator(),
        "FI" => new FI_CountryContextValidator(),
        "FR" => new FR_CountryContextValidator(),
        "GB" => new GB_CountryContextValidator(),
        "HR" => new HR_CountryContextValidator(),
        "HU" => new HU_CountryContextValidator(),
        "IE" => new IE_CountryContextValidator(),
        "IT" => new IT_CountryContextValidator(),
        "LT" => new LT_CountryContextValidator(),
        "LU" => new LU_CountryContextValidator(),
        "LV" => new LV_CountryContextValidator(),
        "MT" => new MT_CountryContextValidator(),
        "NL" => new NL_CountryContextValidator(),
        "PL" => new PL_CountryContextValidator(),
        "PT" => new PT_CountryContextValidator(),
        "RO" => new RO_CountryContextValidator(),
        "SE" => new SE_CountryContextValidator(),
        "SI" => new SI_CountryContextValidator(),
        "SK" => new SK_CountryContextValidator(),
        _ => new UnknownCountryContextValidator()
    };

    public static bool IsVatNumberValid(string countryCode, string vatNumber)
    {
        if (string.IsNullOrEmpty(countryCode))
            return false;
        if (string.IsNullOrEmpty(vatNumber))
            return false;
        return GetValidator(countryCode).IsVatNumberValid(vatNumber);
    }

    public static bool IsVatRecipientCodeValid(string countryCode, string recipientCode)
    {
        if (string.IsNullOrEmpty(countryCode))
            return false;
        if (string.IsNullOrEmpty(recipientCode))
            return false;
        return GetValidator(countryCode).IsVatRecipientCodeValid(recipientCode);
    }
    #endregion
}
