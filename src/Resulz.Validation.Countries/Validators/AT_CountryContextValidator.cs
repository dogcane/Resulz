using System.Text.RegularExpressions;

namespace Resulz.Validation.Countries.Validators;

public partial class AT_CountryContextValidator : BaseCountryContextValidator
{
    #region Fields
    private static readonly Regex vatNumberFormat = AT_VATRegex();

    [GeneratedRegex("^ATU\\d{8}$", RegexOptions.Compiled)]
    private static partial Regex AT_VATRegex();
    #endregion

    #region Ctor
    public AT_CountryContextValidator() : base("AT") { }
    #endregion

    #region Methods
    public override bool IsVatNumberValid(string vatNumber) => vatNumberFormat.IsMatch(vatNumber);
    
    #endregion
}