using System.Text.RegularExpressions;

namespace Resulz.Validation.Countries.Validators;

public class IT_CountryContextValidator : BaseCountryContextValidator
{
    #region Fields
    private static readonly Regex vatNumberFormat = new("^IT\\d{11}$", RegexOptions.Compiled);
    private static readonly Regex recipientCodeFormat = new("^[a-zA-Z0-9]{7}$", RegexOptions.Compiled);
    #endregion

    #region Ctor
    public IT_CountryContextValidator() : base("IT") { }
    #endregion

    #region Methods
    public override bool IsVatNumberValid(string vatNumber)
    {
        // Check if VAT number matches the pattern
        if (!vatNumberFormat.IsMatch(vatNumber))
        {
            return false;
        }
        string digits = vatNumber[2..]; // Extract the digits part, excluding the country code
        // Calculate and check the control sum
        int sum = 0;
        for (int i = 0; i < digits.Length - 1; i++)
        {
            int digit = int.Parse(digits[i].ToString());
            if ((i + 1) % 2 == 0)
            {
                digit *= 2;
                if (digit > 9)
                {
                    digit -= 9;
                }
            }
            sum += digit;
        }
        int controlSum = int.Parse(digits[10].ToString());
        int calculatedControlSum = sum % 10 == 0 ? 0 : 10 - sum % 10;
        return controlSum == calculatedControlSum;
    }

    public override bool IsVatRecipientCodeValid(string recipientCode) => recipientCodeFormat.IsMatch(recipientCode);
    #endregion
}
