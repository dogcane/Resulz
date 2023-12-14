namespace Resulz.Validation.Countries;

public interface ICountryContextValidator
{
    bool IsVatNumberValid(string vatNumber);
    bool IsVatRecipientCodeValid(string recipientCode);
}
