namespace Resulz.Validation.Countries.Validators;

public abstract class BaseCountryContextValidator : ICountryContextValidator
{
    #region Properties
    public string CountryCode { get; protected set; } = string.Empty;
    #endregion

    #region Ctor
    protected BaseCountryContextValidator(string countryCode) => CountryCode = countryCode;
    #endregion

    #region Methods
    public virtual bool IsVatRecipientCodeValid(string recipientCode) => true;

    public virtual bool IsVatNumberValid(string vatNumber) => true;
    #endregion
}
