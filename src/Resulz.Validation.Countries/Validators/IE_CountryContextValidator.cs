using System.Text.RegularExpressions;

namespace Resulz.Validation.Countries.Validators;

public class IE_CountryContextValidator : BaseCountryContextValidator
{
    #region Fields
    private static readonly Regex vatNumberFormat = new(@"^IE\d{7}[A-Z]{1,2}$", RegexOptions.Compiled);
    #endregion

    #region Ctor
    public IE_CountryContextValidator() : base("IE") { }
    #endregion

    #region Methods
    public override bool IsVatNumberValid(string vatNumber) => vatNumberFormat.IsMatch(vatNumber);
    #endregion
}
