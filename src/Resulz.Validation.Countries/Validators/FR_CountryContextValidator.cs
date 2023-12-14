using System.Text.RegularExpressions;

namespace Resulz.Validation.Countries.Validators;

public class FR_CountryContextValidator : BaseCountryContextValidator
{
    #region Fields
    private static readonly Regex vatNumberFormat = new(@"^FR\d{11}$", RegexOptions.Compiled);
    #endregion

    #region Ctor
    public FR_CountryContextValidator() : base("FR") { }
    #endregion

    #region Methods
    public override bool IsVatNumberValid(string vatNumber) => vatNumberFormat.IsMatch(vatNumber);
    #endregion
}
