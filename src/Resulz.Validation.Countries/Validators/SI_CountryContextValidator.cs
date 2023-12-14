using System.Text.RegularExpressions;

namespace Resulz.Validation.Countries.Validators;

public class SI_CountryContextValidator : BaseCountryContextValidator
{
    #region Fields
    private static readonly Regex vatNumberFormat = new(@"^SI\d{8}$", RegexOptions.Compiled);
    #endregion

    #region Ctor
    public SI_CountryContextValidator() : base("SI") { }
    #endregion

    #region Methods
    public override bool IsVatNumberValid(string vatNumber) => vatNumberFormat.IsMatch(vatNumber);
    #endregion
}
