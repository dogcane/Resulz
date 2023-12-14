using System.Text.RegularExpressions;

namespace Resulz.Validation.Countries.Validators;

public class SK_CountryContextValidator : BaseCountryContextValidator
{
    #region Fields
    private static readonly Regex vatNumberFormat = new(@"^SK\d{10}$", RegexOptions.Compiled);
    #endregion

    #region Ctor
    public SK_CountryContextValidator() : base("SK") { }
    #endregion

    #region Methods
    public override bool IsVatNumberValid(string vatNumber) => vatNumberFormat.IsMatch(vatNumber);
    #endregion
}
