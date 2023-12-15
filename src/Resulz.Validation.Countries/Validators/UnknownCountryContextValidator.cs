namespace Resulz.Validation.Countries.Validators;

public class UnknownCountryContextValidator : ICountryContextValidator
{
    public virtual bool IsVatRecipientCodeValid(string recipientCode) => false;
    public virtual bool IsVatNumberValid(string vatNumber) => false;
}
