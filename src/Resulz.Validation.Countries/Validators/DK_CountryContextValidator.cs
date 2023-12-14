using System.Text.RegularExpressions;

namespace Resulz.Validation.Countries.Validators;

public class DK_CountryContextValidator : BaseCountryContextValidator
{
    #region Fields
    private static readonly Regex vatNumberFormat = new(@"^DK\d{8}$", RegexOptions.Compiled);
    #endregion

    #region Ctor
    public DK_CountryContextValidator() : base("DK") { }
    #endregion

    #region Methods
    public override bool IsVatNumberValid(string vatNumber) => vatNumberFormat.IsMatch(vatNumber);
    #endregion
}
