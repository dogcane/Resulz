using System.Text.RegularExpressions;

namespace Resulz.Validation.Countries.Validators;

public class BE_CountryContextValidator : BaseCountryContextValidator
{
    #region Fields
    private static readonly Regex vatNumberFormat = new(@"^BE\d{10}$", RegexOptions.Compiled);
    #endregion

    #region Ctor
    public BE_CountryContextValidator() : base("BE") { }
    #endregion

    #region Methods
    public override bool IsVatNumberValid(string vatNumber) => vatNumberFormat.IsMatch(vatNumber);
    #endregion
}
