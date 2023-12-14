using System.Text.RegularExpressions;

namespace Resulz.Validation.Countries.Validators;

public class ES_CountryContextValidator : BaseCountryContextValidator
{
    #region Fields
    private static readonly Regex vatNumberFormat = new(@"^ES[A-Z0-9]\d{7}[A-Z0-9]$", RegexOptions.Compiled);
    #endregion

    #region Ctor
    public ES_CountryContextValidator() : base("ES") { }
    #endregion

    #region Methods
    public override bool IsVatNumberValid(string vatNumber) => vatNumberFormat.IsMatch(vatNumber);
    #endregion
}
