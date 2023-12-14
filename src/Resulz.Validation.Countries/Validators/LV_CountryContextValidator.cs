using System.Text.RegularExpressions;

namespace Resulz.Validation.Countries.Validators;

public class LV_CountryContextValidator : BaseCountryContextValidator
{
    #region Fields
    private static readonly Regex vatNumberFormat = new(@"^LV\d{11}$", RegexOptions.Compiled);
    #endregion

    #region Ctor
    public LV_CountryContextValidator() : base("LV") { }
    #endregion

    #region Methods
    public override bool IsVatNumberValid(string vatNumber) => vatNumberFormat.IsMatch(vatNumber);
    #endregion
}
