using System.Text.RegularExpressions;

namespace Resulz.Validation.Countries.Validators;

public class BG_CountryContextValidator : BaseCountryContextValidator
{
    #region Fields
    private static readonly Regex vatNumberFormat = new(@"^BG\d{9,10}$", RegexOptions.Compiled);
    #endregion

    #region Ctor
    public BG_CountryContextValidator() : base("BG") { }
    #endregion

    #region Methods
    public override bool IsVatNumberValid(string vatNumber) => vatNumberFormat.IsMatch(vatNumber);
    #endregion
}
