using Microsoft.VisualStudio.TestTools.UnitTesting;
using Resulz.Validation.Countries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resulz.Validation.Countries.Tests
{
    [TestClass()]
    public class CountryValidationExtensionsTests
    {
        [TestMethod()]
        [DataRow("IT53078050415", "IT")]
        [DataRow("DE012345678", "DE")]
        public void ValidateVatNumberSuccess(string vatNumber, string country)
        {
            var result = OperationResult
                .MakeSuccess()
                .With(vatNumber, nameof(vatNumber)).ValidateVatNumber(country)
                .Result;
            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.Errors.Count() == 0);
        }

        [TestMethod()]
        [DataRow("IT12345", "IT")]
        [DataRow("", "IT")]
        [DataRow("DE12345", "DE")]
        public void ValidateVatNumberTestFailure(string vatNumber, string country)
        {
            var result = OperationResult
                .MakeSuccess()
                .With("", "vatNumber").ValidateVatNumber("IT")
                .Result;
            var error = ErrorMessage.Create(nameof(vatNumber), string.Format("{0}_NOT_VATNUMBER", nameof(vatNumber).ToUpper()));
            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.Errors.Count() == 1);
            Assert.IsTrue(result.Errors.Contains(error));
        }

        [TestMethod()]
        [DataRow("ABC1234", "IT")]
        [DataRow("", "DE")]
        public void ValidateVatRecipientCodeSuccess(string recipientCode, string country)
        {
            var result = OperationResult
                .MakeSuccess()
                .With(recipientCode, nameof(recipientCode)).ValidateVatRecipientCode(country)
                .Result;
            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.Errors.Count() == 0);
        }

        [TestMethod()]
        [DataRow("", "IT")]
        public void ValidateVatRecipientCodeFailure(string recipientCode, string country)
        {
            var result = OperationResult
                .MakeSuccess()
                .With(recipientCode, nameof(recipientCode)).ValidateVatRecipientCode(country)
                .Result;
            var error = ErrorMessage.Create(nameof(recipientCode), string.Format("{0}_NOT_VATRECIPIENTCODE", nameof(recipientCode).ToUpper()));
            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.Errors.Count() == 1);
            Assert.IsTrue(result.Errors.Contains(error));
        }
    }
}