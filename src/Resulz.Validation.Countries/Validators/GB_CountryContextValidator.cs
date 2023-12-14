using System.Text.RegularExpressions;

namespace Resulz.Validation.Countries.Validators;

public class GB_CountryContextValidator : BaseCountryContextValidator
{
    #region Fields
    private static readonly Regex vatNumberFormat = new(@"^GB\d{9}$", RegexOptions.Compiled);
    #endregion

    #region Ctor
    public GB_CountryContextValidator() : base("GB") { }
    #endregion

    #region Methods
    public override bool IsVatNumberValid(string vatNumber) => vatNumberFormat.IsMatch(vatNumber);
    #endregion
}
