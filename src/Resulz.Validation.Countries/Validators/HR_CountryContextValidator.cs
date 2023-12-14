using System.Text.RegularExpressions;

namespace Resulz.Validation.Countries.Validators;

public class HR_CountryContextValidator : BaseCountryContextValidator
{
    #region Fields
    private static readonly Regex vatNumberFormat = new(@"^HR\d{11}$", RegexOptions.Compiled);
    #endregion

    #region Ctor
    public HR_CountryContextValidator() : base("HR") { }
    #endregion

    #region Methods
    public override bool IsVatNumberValid(string vatNumber) => vatNumberFormat.IsMatch(vatNumber);
    #endregion
}
