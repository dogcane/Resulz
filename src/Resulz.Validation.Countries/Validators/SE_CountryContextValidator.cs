﻿using System.Text.RegularExpressions;

namespace Resulz.Validation.Countries.Validators;

public class SE_CountryContextValidator : BaseCountryContextValidator
{
    #region Fields
    private static readonly Regex vatNumberFormat = new(@"^SE\d{10}$", RegexOptions.Compiled);
    #endregion

    #region Ctor
    public SE_CountryContextValidator() : base("SE") { }
    #endregion

    #region Methods
    public override bool IsVatNumberValid(string vatNumber) => vatNumberFormat.IsMatch(vatNumber);
    #endregion
}
