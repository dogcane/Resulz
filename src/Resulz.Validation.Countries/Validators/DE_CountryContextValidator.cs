using System.Text.RegularExpressions;

namespace Resulz.Validation.Countries.Validators;

public sealed class DE_CountryContextValidator : BaseCountryContextValidator
{
    #region Fields
    private static readonly Regex vatNumberFormat = new("^DE\\d{9}$", RegexOptions.Compiled);
    #endregion

    #region Ctor
    public DE_CountryContextValidator() : base("DE") { }
    #endregion

    #region Methods
    public override bool IsVatNumberValid(string vatNumber) => vatNumberFormat.IsMatch(vatNumber);
    #endregion
}
