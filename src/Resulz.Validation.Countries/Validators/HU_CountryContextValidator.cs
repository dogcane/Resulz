using System.Text.RegularExpressions;

namespace Resulz.Validation.Countries.Validators;

public class HU_CountryContextValidator : BaseCountryContextValidator
{
    #region Fields
    private static readonly Regex vatNumberFormat = new(@"^HU\d{8}$", RegexOptions.Compiled);
    #endregion

    #region Ctor
    public HU_CountryContextValidator() : base("HU") { }
    #endregion

    #region Methods
    public override bool IsVatNumberValid(string vatNumber) => vatNumberFormat.IsMatch(vatNumber);
    #endregion
}
