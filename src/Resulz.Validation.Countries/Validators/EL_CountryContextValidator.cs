using System.Text.RegularExpressions;

namespace Resulz.Validation.Countries.Validators;

public class EL_CountryContextValidator : BaseCountryContextValidator
{
    #region Fields
    private static readonly Regex vatNumberFormat = new(@"^EL\d{9}$", RegexOptions.Compiled);
    #endregion

    #region Ctor
    public EL_CountryContextValidator() : base("EL") { }
    #endregion

    #region Methods
    public override bool IsVatNumberValid(string vatNumber) => vatNumberFormat.IsMatch(vatNumber);
    #endregion
}
