using System.Text.RegularExpressions;

namespace Resulz.Validation.Countries.Validators;

public class MT_CountryContextValidator : BaseCountryContextValidator
{
    #region Fields
    private static readonly Regex vatNumberFormat = new(@"^MT\d{8}$", RegexOptions.Compiled);
    #endregion

    #region Ctor
    public MT_CountryContextValidator() : base("MT") { }
    #endregion

    #region Methods
    public override bool IsVatNumberValid(string vatNumber) => vatNumberFormat.IsMatch(vatNumber);
    #endregion
}
