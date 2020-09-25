using Microsoft.VisualStudio.TestTools.UnitTesting;
using Resulz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Resulz.UnitTest
{
    [TestClass()]
    public class OperationResultOfTTests
    {
        [TestMethod()]
        public void OperationResultTest()
        {
            var result = new OperationResult<int>(0);
            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.Errors.Count() == 0);
            Assert.AreEqual(result.Value, 0);
        }

        [TestMethod()]
        public void OperationResultTest1()
        {
            var error = ErrorMessage.Create("Prop", "Error");
            var result = new OperationResult<int>(new[] { error });
            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.Errors.Count() == 1);
            Assert.IsTrue(result.Errors.Contains(error));
        }

        [TestMethod()]
        public void MakeSuccessTest()
        {
            var result = OperationResult<int>.MakeSuccess(0);
            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.Errors.Count() == 0);
            Assert.AreEqual(result.Value, 0);
        }

        [TestMethod()]
        public void MakeFailureTest()
        {
            var error = ErrorMessage.Create("Prop", "Error");
            var result = OperationResult<int>.MakeFailure(error);
            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.Errors.Count() == 1);
            Assert.IsTrue(result.Errors.Contains(error));
        }

        [TestMethod()]
        public void MakeFailureTest1()
        {
            var error = ErrorMessage.Create("Prop", "Error");
            var result = OperationResult<int>.MakeFailure(new[] { error });
            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.Errors.Count() == 1);
            Assert.IsTrue(result.Errors.Contains(error));
        }

        [TestMethod()]
        public void AppendErrorTest()
        {
            var result = OperationResult<int>.MakeSuccess(0);
            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.Errors.Count() == 0);
            Assert.AreEqual(result.Value, 0);
            result.AppendError("Prop", "Error");
            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.Errors.Count() == 1);
            Assert.IsTrue(result.Errors.Contains(ErrorMessage.Create("Prop", "Error")));
        }

        [TestMethod()]
        public void AppendErrorTest1()
        {
            var result = OperationResult<int>.MakeSuccess(0);
            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.Errors.Count() == 0);
            Assert.AreEqual(result.Value, 0);
            var error = ErrorMessage.Create("Prop", "Error");
            result.AppendError(error);
            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.Errors.Count() == 1);
            Assert.IsTrue(result.Errors.Contains(error));
        }

        [TestMethod()]
        public void AppendErrorsTest()
        {
            var result = OperationResult<int>.MakeSuccess(0);
            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.Errors.Count() == 0);
            Assert.AreEqual(result.Value, 0);
            var error1 = ErrorMessage.Create("Prop1", "Error1");
            var error2 = ErrorMessage.Create("Prop2", "Error2");
            var errors = new[] { error1, error2 };
            result.AppendErrors(errors);
            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.Errors.Count() == 2);
            Assert.IsTrue(result.Errors.Contains(error1));
            Assert.IsTrue(result.Errors.Contains(error2));
        }

        [TestMethod()]
        public void AppendContextPrefixTest()
        {
            var result = OperationResult<int>.MakeSuccess(0);
            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.Errors.Count() == 0);
            Assert.AreEqual(result.Value, 0);
            var error = ErrorMessage.Create("Prop", "Error");
            result.AppendError(error);
            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.Errors.Count() == 1);
            Assert.IsTrue(result.Errors.Contains(error));
            result.AppendContextPrefix("Prefix.");
            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.Errors.Count() == 1);
            Assert.IsFalse(result.Errors.Contains(error));
            Assert.IsTrue(result.Errors.Contains(ErrorMessage.Create("Prefix.Prop", "Error")));
        }

        [TestMethod()]
        public void TranslateContextTest()
        {
            var result = OperationResult<int>.MakeSuccess(0);
            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.Errors.Count() == 0);
            Assert.AreEqual(result.Value, 0);
            var error = ErrorMessage.Create("Prop", "Error");
            result.AppendError(error);
            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.Errors.Count() == 1);
            Assert.IsTrue(result.Errors.Contains(error));
            result.TranslateContext("Prop", "NewProp");
            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.Errors.Count() == 1);
            Assert.IsFalse(result.Errors.Contains(error));
            Assert.IsTrue(result.Errors.Contains(ErrorMessage.Create("NewProp", "Error")));
        }
    }
}