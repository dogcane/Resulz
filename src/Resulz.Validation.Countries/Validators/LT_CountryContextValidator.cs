using System.Text.RegularExpressions;

namespace Resulz.Validation.Countries.Validators;

public class LT_CountryContextValidator : BaseCountryContextValidator
{
    #region Fields
    private static readonly Regex vatNumberFormat = new(@"^LT\d{9,12}$", RegexOptions.Compiled);
    #endregion

    #region Ctor
    public LT_CountryContextValidator() : base("LT") { }
    #endregion

    #region Methods
    public override bool IsVatNumberValid(string vatNumber) => vatNumberFormat.IsMatch(vatNumber);
    #endregion
}