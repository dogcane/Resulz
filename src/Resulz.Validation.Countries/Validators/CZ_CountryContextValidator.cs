using System.Text.RegularExpressions;

namespace Resulz.Validation.Countries.Validators;

public class CZ_CountryContextValidator : BaseCountryContextValidator
{
    #region Fields
    private static readonly Regex vatNumberFormat = new(@"^CZ\d{8,10}$", RegexOptions.Compiled);
    #endregion

    #region Ctor
    public CZ_CountryContextValidator() : base("CZ") { }
    #endregion

    #region Methods
    public override bool IsVatNumberValid(string vatNumber) => vatNumberFormat.IsMatch(vatNumber);
    #endregion
}
