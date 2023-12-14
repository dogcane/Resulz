namespace Resulz.Validation.Countries.Validators;

public class UnknownCountryContextValidator : ICountryContextValidator
{
    public virtual bool IsVatRecipientCodeValid(string recipientCode) => true;
    public virtual bool IsVatNumberValid(string vatNumber) => true;
}
