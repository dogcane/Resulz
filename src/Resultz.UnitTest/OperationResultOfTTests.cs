using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            Assert.IsTrue(result.Errors.Count() == 0);
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
            Assert.ThrowsException<ArgumentNullException>(() => new OperationResult<int>(null));
        }

        [TestMethod()]
        public void MakeSuccess()
        {
            var result = OperationResult<int>.MakeSuccess(0);
            Assert.IsTrue(result.Success);            
            Assert.IsTrue(result.Errors.Count() == 0);
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
            Assert.ThrowsException<ArgumentNullException>(() => OperationResult<int>.MakeFailure(null));
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
            Assert.ThrowsException<ArgumentNullException>(() => result.AppendError(null, "Error"));
            Assert.ThrowsException<ArgumentNullException>(() => result.AppendError("Prop", null));
            Assert.ThrowsException<ArgumentNullException>(() => result.AppendError(null, null));
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
            Assert.ThrowsException<ArgumentNullException>(() => result.AppendErrors(null));
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
            Assert.ThrowsException<ArgumentNullException>(() => result.AppendContextPrefix(null));
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
            Assert.ThrowsException<ArgumentNullException>(() => result.TranslateContext("Prop", null));
            Assert.ThrowsException<ArgumentNullException>(() => result.TranslateContext(null, "NewProp"));
            Assert.ThrowsException<ArgumentNullException>(() => result.TranslateContext(null, null));
        }
    }
}