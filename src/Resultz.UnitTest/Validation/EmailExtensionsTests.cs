using Microsoft.VisualStudio.TestTools.UnitTesting;
using Resulz.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resulz.Validation.UnitTest
{
    [TestClass()]
    public class EmailExtensionsTests
    {
        [TestMethod()]
        [DataRow("email@email.com")]
        [DataRow("email+01@email.com")]
        [DataRow("email@email.co.uk")]
        [DataRow("13456@123.com")]
        [DataRow("n.surname@my-company.net")]
        public void EmailTestSuccess(string stremail)
        {
            var result = OperationResult
                .MakeSuccess()
                .With(stremail, nameof(stremail)).Email()
                .Result;
            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.Errors.Count() == 0);
        }

        [TestMethod()]
        [DataRow("email")]
        [DataRow("email@")]
        [DataRow("email@domain")]
        [DataRow("email@domain.")]
        [DataRow("")]
        [DataRow(null)]
        public void EmailTestFail(string stremail)
        {
            var result = OperationResult
                .MakeSuccess()
                .With(stremail, nameof(stremail)).Email()
                .Result;
            var error = ErrorMessage.Create(nameof(stremail), string.Format("{0}_NOT_EMAIL", nameof(stremail).ToUpper()));
            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.Errors.Count() == 1);
            Assert.IsTrue(result.Errors.Contains(error));
        }
    }
}