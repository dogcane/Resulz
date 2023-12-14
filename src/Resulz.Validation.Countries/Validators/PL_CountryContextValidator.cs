using System.Text.RegularExpressions;

namespace Resulz.Validation.Countries.Validators;

public class PL_CountryContextValidator : BaseCountryContextValidator
{
    #region Fields
    private static readonly Regex vatNumberFormat = new(@"^PL\d{10}$", RegexOptions.Compiled);
    #endregion

    #region Ctor
    public PL_CountryContextValidator() : base("PL") { }
    #endregion

    #region Methods
    public override bool IsVatNumberValid(string vatNumber) => vatNumberFormat.IsMatch(vatNumber);
    #endregion
}
