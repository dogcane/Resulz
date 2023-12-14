using System.Text.RegularExpressions;

namespace Resulz.Validation.Countries.Validators;

public class FI_CountryContextValidator : BaseCountryContextValidator
{
    #region Fields
    private static readonly Regex vatNumberFormat = new(@"^FI\d{8}$", RegexOptions.Compiled);
    #endregion

    #region Ctor
    public FI_CountryContextValidator() : base("FI") { }
    #endregion

    #region Methods
    public override bool IsVatNumberValid(string vatNumber) => vatNumberFormat.IsMatch(vatNumber);
    #endregion
}
