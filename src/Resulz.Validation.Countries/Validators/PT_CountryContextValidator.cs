using System.Text.RegularExpressions;

namespace Resulz.Validation.Countries.Validators;

public class PT_CountryContextValidator : BaseCountryContextValidator
{
    #region Fields
    private static readonly Regex vatNumberFormat = new(@"^PT\d{9}$", RegexOptions.Compiled);
    #endregion

    #region Ctor
    public PT_CountryContextValidator() : base("PT") { }
    #endregion

    #region Methods
    public override bool IsVatNumberValid(string vatNumber) => vatNumberFormat.IsMatch(vatNumber);
    #endregion
}
