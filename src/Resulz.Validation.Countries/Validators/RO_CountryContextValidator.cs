using System.Text.RegularExpressions;

namespace Resulz.Validation.Countries.Validators;

public class RO_CountryContextValidator : BaseCountryContextValidator
{
    #region Fields
    private static readonly Regex vatNumberFormat = new(@"^RO\d{2,10}$", RegexOptions.Compiled);
    #endregion

    #region Ctor
    public RO_CountryContextValidator() : base("RO") { }
    #endregion

    #region Methods
    public override bool IsVatNumberValid(string vatNumber) => vatNumberFormat.IsMatch(vatNumber);
    #endregion
}
