using System.Text.RegularExpressions;

namespace Resulz.Validation.Countries.Validators;

public class LU_CountryContextValidator : BaseCountryContextValidator
{
    #region Fields
    private static readonly Regex vatNumberFormat = new(@"^LU\d{8}$", RegexOptions.Compiled);
    #endregion

    #region Ctor
    public LU_CountryContextValidator() : base("LU") { }
    #endregion

    #region Methods
    public override bool IsVatNumberValid(string vatNumber) => vatNumberFormat.IsMatch(vatNumber);
    #endregion
}
