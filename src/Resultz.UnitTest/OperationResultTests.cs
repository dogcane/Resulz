using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Resulz.UnitTest
{
    [TestClass()]
    public class OperationResultTests
    {
        [TestMethod()]
        public void OperationResult_Empty_Costructor()
        {
            var result = new OperationResult();
            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.Errors.Count() == 0);
        }

        [TestMethod()]
        public void OperationResult_Constructor_With_ErrorMessages()
        {
            var errors = new[] {
                ErrorMessage.Create("Prop", "Error"),
                ErrorMessage.Create("Prop1", "Error1")
            };
            var result = new OperationResult(errors);
            Assert.IsFalse(result.Success);
            CollectionAssert.AreEquivalent(result.Errors.ToArray(), errors);
        }

        [TestMethod()]
        public void OperationResult_Constructor_With_Null_ErrorMessages()
        {
#pragma warning disable CS8625 // Non è possibile convertire il valore letterale Null in tipo riferimento che non ammette i valori Null.
            Assert.ThrowsException<ArgumentNullException>(() => new OperationResult(null));
#pragma warning restore CS8625 // Non è possibile convertire il valore letterale Null in tipo riferimento che non ammette i valori Null.
        }

        [TestMethod()]
        public void MakeSuccess()
        {
            var result = OperationResult.MakeSuccess();
            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.Errors.Count() == 0);
        }

        [TestMethod()]
        public void MakeFailure_With_ErrorMessage()
        {
            var error = ErrorMessage.Create("Prop", "Error");
            var result = OperationResult.MakeFailure(error);
            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.Errors.Count() == 1);
            CollectionAssert.Contains(result.Errors.ToArray(), error);
        }

        [TestMethod()]
        public void MakeFailure_With_ErrorMessages()
        {
            var errors = new[] {
                ErrorMessage.Create("Prop1", "Error1"),
                ErrorMessage.Create("Prop2", "Error2")
            };
            var result = OperationResult.MakeFailure(errors);
            Assert.IsFalse(result.Success);
            CollectionAssert.AreEquivalent(errors, result.Errors.ToArray());
        }

        [TestMethod()]
        public void MakeFailure_With_Null_ErrorMessages()
        {
            ErrorMessage[]? errors = null;
#pragma warning disable CS8604 // Possibile argomento di riferimento Null.
            Assert.ThrowsException<ArgumentNullException>(() => OperationResult.MakeFailure(errors));
#pragma warning restore CS8604 // Possibile argomento di riferimento Null.
        }

        [TestMethod()]
        public void AppendError_With_Values()
        {
            var result = OperationResult.MakeSuccess();
            result.AppendError("Prop", "Error");
            Assert.IsFalse(result.Success);
            CollectionAssert.Contains(result.Errors.ToArray(), ErrorMessage.Create("Prop", "Error"));
        }

        [TestMethod()]
        public void AppendError_With_Null_Values()
        {
            var result = OperationResult.MakeSuccess();
            Assert.ThrowsException<ArgumentNullException>(() => result.AppendError(null, "Error"));
            Assert.ThrowsException<ArgumentNullException>(() => result.AppendError("Prop", null));
            Assert.ThrowsException<ArgumentNullException>(() => result.AppendError(null, null));            
        }

        [TestMethod()]
        public void AppendError_With_ErrorMessage()
        {
            var result = OperationResult.MakeSuccess();
            var error = ErrorMessage.Create("Prop", "Error");
            result.AppendError(error);
            Assert.IsFalse(result.Success);
            CollectionAssert.Contains(result.Errors.ToArray(), error);
        }

        [TestMethod()]
        public void AppendErrors_With_ErrorMessages()
        {
            var result = OperationResult.MakeSuccess();
            var errors = new [] {
                ErrorMessage.Create("Prop1", "Error1"),
                ErrorMessage.Create("Prop2", "Error2")
            };
            result.AppendErrors(errors);
            Assert.IsFalse(result.Success);
            CollectionAssert.AreEquivalent(errors, result.Errors.ToArray());
        }

        [TestMethod()]
        public void AppendErrors_With_Null_ErrorMessages()
        {
            var result = OperationResult.MakeSuccess();
#pragma warning disable CS8625 // Non è possibile convertire il valore letterale Null in tipo riferimento che non ammette i valori Null.
            Assert.ThrowsException<ArgumentNullException>(() => result.AppendErrors(null));
#pragma warning restore CS8625 // Non è possibile convertire il valore letterale Null in tipo riferimento che non ammette i valori Null.
        }

        [TestMethod()]
        public void AppendContextPrefix_With_Value()
        {
            var result = OperationResult.MakeSuccess();
            var errors = new[] {
                ErrorMessage.Create("Prop1", "Error1"),
                ErrorMessage.Create("Prop2", "Error2")
            };
            result.AppendErrors(errors);
            result.AppendContextPrefix("Prefix.");
            foreach (var error in result.Errors)
            {
                StringAssert.StartsWith(error.Context, "Prefix.");
            }
        }

        [TestMethod()]
        public void AppendContextPrefix_With_Null_Value()
        {
            var result = OperationResult.MakeSuccess();
#pragma warning disable CS8625 // Non è possibile convertire il valore letterale Null in tipo riferimento che non ammette i valori Null.
            Assert.ThrowsException<ArgumentNullException>(() => result.AppendContextPrefix(null));
#pragma warning restore CS8625 // Non è possibile convertire il valore letterale Null in tipo riferimento che non ammette i valori Null.
        }

        [TestMethod()]
        public void TranslateContext_With_Value()
        {
            var error = ErrorMessage.Create("Prop", "Error");
            var errorTranslated = ErrorMessage.Create("NewProp", "Error");
            var result = OperationResult.MakeFailure(error);
            CollectionAssert.Contains(result.Errors.ToArray(), error);
            result.TranslateContext("Prop", "NewProp");
            CollectionAssert.DoesNotContain(result.Errors.ToArray(), error);
            CollectionAssert.Contains(result.Errors.ToArray(), errorTranslated);
        }

        [TestMethod()]
        public void TranslateContext_With_Null_Values()
        {
            var result = OperationResult.MakeFailure(ErrorMessage.Create("Prop", "Error"));
#pragma warning disable CS8625 // Non è possibile convertire il valore letterale Null in tipo riferimento che non ammette i valori Null.
            Assert.ThrowsException<ArgumentNullException>(() => result.TranslateContext("Prop", null));
            Assert.ThrowsException<ArgumentNullException>(() => result.TranslateContext(null, "NewProp"));
            Assert.ThrowsException<ArgumentNullException>(() => result.TranslateContext(null, null));
#pragma warning restore CS8625 // Non è possibile convertire il valore letterale Null in tipo riferimento che non ammette i valori Null.
        }

        [TestMethod()]
        public void AdditionalInfo_With_Value()
        {
            var result = OperationResult.MakeFailure(ErrorMessage.Create("Prop", "Error")).SetAdditionalInfo("my tag");
            Assert.AreEqual("my tag", result.AdditionalInfo);
        }

        [TestMethod()]
        public void AdditionalInfo_With_Empty_Value()
        {
            var result = OperationResult.MakeFailure(ErrorMessage.Create("Prop", "Error")).SetAdditionalInfo("");
            Assert.AreEqual(string.Empty, result.AdditionalInfo);
        }

        [TestMethod()]
        public void AdditionalInfo_With_Multiple_Values()
        {
            var result = OperationResult.MakeFailure(ErrorMessage.Create("Prop", "Error")).SetAdditionalInfo("my tag 01", "my tag 02");
            Assert.AreEqual("my tag 01|my tag 02", result.AdditionalInfo);
        }

        [TestMethod()]
        public void AdditionalInfo_With_Null_Value()
        {
            var result = OperationResult.MakeFailure(ErrorMessage.Create("Prop", "Error"));
#pragma warning disable CS8625 // Non è possibile convertire il valore letterale Null in tipo riferimento che non ammette i valori Null.
            Assert.ThrowsException<ArgumentNullException>(() => result.SetAdditionalInfo(null));
#pragma warning restore CS8625 // Non è possibile convertire il valore letterale Null in tipo riferimento che non ammette i valori Null.
        }

        [TestMethod()]
        public void AdditionalInfo_With_And_Operator()
        {
            var result01 = OperationResult.MakeFailure(ErrorMessage.Create("Prop", "Error")).SetAdditionalInfo("my tag 01");
            var result02 = OperationResult.MakeFailure(ErrorMessage.Create("Prop", "Error")).SetAdditionalInfo("my tag 02");
            var result03 = result01 & result02;
            Assert.AreEqual("my tag 01|my tag 02", result03.AdditionalInfo);
        }
    }
}
