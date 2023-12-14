using System.Text.RegularExpressions;

namespace Resulz.Validation.Countries.Validators;

public class EE_CountryContextValidator : BaseCountryContextValidator
{
    #region Fields
    private static readonly Regex vatNumberFormat = new(@"^EE\d{9}$", RegexOptions.Compiled);
    #endregion

    #region Ctor
    public EE_CountryContextValidator() : base("EE") { }
    #endregion

    #region Methods
    public override bool IsVatNumberValid(string vatNumber) => vatNumberFormat.IsMatch(vatNumber);
    #endregion
}
