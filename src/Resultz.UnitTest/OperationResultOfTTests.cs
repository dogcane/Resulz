﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Resulz.UnitTest
{
    [TestClass()]
    public class OperationResultOfTTests
    {
        [TestMethod()]
        public void OperationResultOfT_Empty_Costructor()
        {
            var result = new OperationResult<int>(0);
            Assert.IsTrue(result.Success);
            Assert.IsFalse(result.Errors.Any());
            Assert.AreEqual(result.Value, 0);
        }

        [TestMethod()]
        public void OperationResultOfT_Constructor_With_ErrorMessages()
        {
            var errors = new[] {
                ErrorMessage.Create("Prop", "Error"),
                ErrorMessage.Create("Prop1", "Error1")
            };
            var result = new OperationResult<int>(errors);
            Assert.IsFalse(result.Success);
            CollectionAssert.AreEquivalent(result.Errors.ToArray(), errors);
        }

        [TestMethod()]
        public void OperationResultOfT_Constructor_With_Null_ErrorMessages()
        {
#pragma warning disable CS8625 // Non è possibile convertire il valore letterale Null in tipo riferimento che non ammette i valori Null.
            Assert.ThrowsException<ArgumentNullException>(() => new OperationResult<int>(null));
#pragma warning restore CS8625 // Non è possibile convertire il valore letterale Null in tipo riferimento che non ammette i valori Null.
        }

        [TestMethod()]
        public void MakeSuccess()
        {
            var result = OperationResult<int>.MakeSuccess(0);
            Assert.IsTrue(result.Success);
            Assert.IsFalse(result.Errors.Any());
            Assert.AreEqual(result.Value, 0);
        }

        [TestMethod()]
        public void MakeFailure_With_ErrorMessage()
        {
            var error = ErrorMessage.Create("Prop", "Error");
            var result = OperationResult<int>.MakeFailure(error);
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
            var result = OperationResult<int>.MakeFailure(errors);
            Assert.IsFalse(result.Success);
            CollectionAssert.AreEquivalent(errors, result.Errors.ToArray());
        }

        [TestMethod()]
        public void MakeFailure_With_Null_ErrorMessages()
        {
            ErrorMessage[]? errors = null;
#pragma warning disable CS8604 // Possibile argomento di riferimento Null.
            Assert.ThrowsException<ArgumentNullException>(() => OperationResult<int>.MakeFailure(errors));
#pragma warning restore CS8604 // Possibile argomento di riferimento Null.
        }

        [TestMethod()]
        public void AppendError_With_Values()
        {
            var result = OperationResult<int>.MakeSuccess(0);
            result.AppendError("Prop", "Error");
            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.Errors.Count() == 1);
            CollectionAssert.Contains(result.Errors.ToArray(), ErrorMessage.Create("Prop", "Error"));
        }

        [TestMethod()]
        public void AppendError_With_Null_Values()
        {
            var result = OperationResult<int>.MakeSuccess(0);
#pragma warning disable CS8625 // Non è possibile convertire il valore letterale Null in tipo riferimento che non ammette i valori Null.
            Assert.ThrowsException<ArgumentNullException>(() => result.AppendError(null, "Error"));
            Assert.ThrowsException<ArgumentNullException>(() => result.AppendError("Prop", null));
            Assert.ThrowsException<ArgumentNullException>(() => result.AppendError(null, null));
#pragma warning restore CS8625 // Non è possibile convertire il valore letterale Null in tipo riferimento che non ammette i valori Null.
        }

        [TestMethod()]
        public void AppendError_With_ErrorMessage()
        {
            var result = OperationResult<int>.MakeSuccess(0);
            var error = ErrorMessage.Create("Prop", "Error");
            result.AppendError(error);
            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.Errors.Count() == 1);
            CollectionAssert.Contains(result.Errors.ToArray(), error);
        }

        [TestMethod()]
        public void AppendErrors_With_ErrorMessages()
        {
            var result = OperationResult<int>.MakeSuccess(0);
            var errors = new[] {
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
            var result = OperationResult<int>.MakeSuccess(0);
#pragma warning disable CS8625 // Non è possibile convertire il valore letterale Null in tipo riferimento che non ammette i valori Null.
            Assert.ThrowsException<ArgumentNullException>(() => result.AppendErrors(null));
#pragma warning restore CS8625 // Non è possibile convertire il valore letterale Null in tipo riferimento che non ammette i valori Null.
        }

        [TestMethod()]
        public void AppendContextPrefix_With_Value()
        {
            var result = OperationResult<int>.MakeSuccess(0);
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
            var result = OperationResult<int>.MakeSuccess(0);
#pragma warning disable CS8625 // Non è possibile convertire il valore letterale Null in tipo riferimento che non ammette i valori Null.
            Assert.ThrowsException<ArgumentNullException>(() => result.AppendContextPrefix(null));
#pragma warning restore CS8625 // Non è possibile convertire il valore letterale Null in tipo riferimento che non ammette i valori Null.
        }

        [TestMethod()]
        public void TranslateContext_With_Value()
        {
            var error = ErrorMessage.Create("Prop", "Error");
            var errorTranslated = ErrorMessage.Create("NewProp", "Error");
            var result = OperationResult<int>.MakeFailure(error);
            CollectionAssert.Contains(result.Errors.ToArray(), error);
            result.TranslateContext("Prop", "NewProp");
            CollectionAssert.DoesNotContain(result.Errors.ToArray(), error);
            CollectionAssert.Contains(result.Errors.ToArray(), errorTranslated);
        }

        [TestMethod()]
        public void TranslateContext_With_Null_Values()
        {
            var result = OperationResult<int>.MakeFailure(ErrorMessage.Create("Prop", "Error"));
#pragma warning disable CS8625 // Non è possibile convertire il valore letterale Null in tipo riferimento che non ammette i valori Null.
            Assert.ThrowsException<ArgumentNullException>(() => result.TranslateContext("Prop", null));
            Assert.ThrowsException<ArgumentNullException>(() => result.TranslateContext(null, "NewProp"));
            Assert.ThrowsException<ArgumentNullException>(() => result.TranslateContext(null, null));
#pragma warning restore CS8625 // Non è possibile convertire il valore letterale Null in tipo riferimento che non ammette i valori Null.
        }

        [TestMethod()]
        public void AdditionalInfo_With_Value()
        {
            var result = OperationResult<int>.MakeFailure(ErrorMessage.Create("Prop", "Error")).SetAdditionalInfo("my tag");
            Assert.AreEqual("my tag", result.AdditionalInfo);
        }

        [TestMethod()]
        public void AdditionalInfo_With_Empty_Value()
        {
            var result = OperationResult<int>.MakeFailure(ErrorMessage.Create("Prop", "Error")).SetAdditionalInfo("");
            Assert.AreEqual(string.Empty, result.AdditionalInfo);
        }

        [TestMethod()]
        public void AdditionalInfo_With_Multiple_Values()
        {
            var result = OperationResult<int>.MakeFailure(ErrorMessage.Create("Prop", "Error")).SetAdditionalInfo("my tag 01", "my tag 02");
            Assert.AreEqual("my tag 01|my tag 02", result.AdditionalInfo);
        }

        [TestMethod()]
        public void AdditionalInfo_With_Null_Value()
        {
            var result = OperationResult<int>.MakeFailure(ErrorMessage.Create("Prop", "Error"));
#pragma warning disable CS8625 // Non è possibile convertire il valore letterale Null in tipo riferimento che non ammette i valori Null.
            Assert.ThrowsException<ArgumentNullException>(() => result.SetAdditionalInfo(null));
#pragma warning restore CS8625 // Non è possibile convertire il valore letterale Null in tipo riferimento che non ammette i valori Null.
        }

        [TestMethod()]
        public void Value_To_Success_Implicit_Operator()
        {
            int value = 0;
            OperationResult<int> result = value;
            Assert.AreEqual(value, result.Value);
        }

        [TestMethod()]
        public void Failed_OperationResult_To_Failed_Implicit_Operator()
        {
            var errors = new[] {
                ErrorMessage.Create("Prop1", "Error1"),
                ErrorMessage.Create("Prop2", "Error2")
            };
            OperationResult result = OperationResult.MakeFailure(errors);
            OperationResult<int> resultOfT = result;
            Assert.IsFalse(resultOfT.Success);
            CollectionAssert.AreEquivalent(errors, resultOfT.Errors.ToArray());
        }

        [TestMethod()]
        public void Succeded_OperationResult_To_Success_Implicit_Operator()
        {
            OperationResult result = OperationResult.MakeSuccess();
            OperationResult<int> resultOfT;
            Assert.ThrowsException<ArgumentException>(() => resultOfT = result);
        }

        [TestMethod()]
        public void Null_OperationResult_To_Null_Implicit_Operator_Throws_Exception()
        {
            OperationResult? result = null;
            OperationResult<int> resultOfT;
#pragma warning disable CS8604 // Possibile argomento di riferimento Null.
            Assert.ThrowsException<ArgumentNullException>(() => resultOfT = result);
#pragma warning restore CS8604 // Possibile argomento di riferimento Null.
        }
    }
}