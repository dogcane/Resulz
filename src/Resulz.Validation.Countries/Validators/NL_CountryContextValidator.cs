using System.Text.RegularExpressions;

namespace Resulz.Validation.Countries.Validators;

public class NL_CountryContextValidator : BaseCountryContextValidator
{
    #region Fields
    private static readonly Regex vatNumberFormat = new(@"^NL\d{9}B\d{2}$", RegexOptions.Compiled);
    #endregion

    #region Ctor
    public NL_CountryContextValidator() : base("NL") { }
    #endregion

    #region Methods
    public override bool IsVatNumberValid(string vatNumber) => vatNumberFormat.IsMatch(vatNumber);
    #endregion
}
