using System.Text.RegularExpressions;

namespace Resulz.Validation.Countries.Validators;

public class CY_CountryContextValidator : BaseCountryContextValidator
{
    #region Fields
    private static readonly Regex vatNumberFormat = new(@"^CY\d{8}[A-Z]$", RegexOptions.Compiled);
    #endregion

    #region Ctor
    public CY_CountryContextValidator() : base("CY") { }
    #endregion

    #region Methods
    public override bool IsVatNumberValid(string vatNumber) => vatNumberFormat.IsMatch(vatNumber);
    #endregion
}
