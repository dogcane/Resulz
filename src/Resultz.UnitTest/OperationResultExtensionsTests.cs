using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Resulz.UnitTest
{
    [TestClass()]
    public class OperationResultExtensionsTests
    {
        [TestMethod()]
        public void IfSuccessExecuteCorrectly()
        {
            var counter = 0;
            var result = OperationResult.MakeSuccess();
            var result2 = result.IfSuccess(res => counter++);
            Assert.IsTrue(result2.Success);
            Assert.IsTrue(counter == 1);
        }

        [TestMethod()]
        public void IfSuccessFailsWithNullArguments()
        {
            OperationResult? result = null;
#pragma warning disable CS8631 // Non è possibile usare il tipo come parametro di tipo nel tipo generico o nel metodo. Il supporto dei valori Null dell'argomento tipo non corrisponde al tipo di vincolo.
#pragma warning disable CS8625 // Non è possibile convertire il valore letterale Null in tipo riferimento che non ammette i valori Null.
            Assert.ThrowsException<ArgumentNullException>(() => result.IfSuccess(null));
            Assert.ThrowsException<ArgumentNullException>(() => result.IfSuccess(res => { }));
            result = OperationResult.MakeSuccess();
            Assert.ThrowsException<ArgumentNullException>(() => result.IfSuccess(null));
#pragma warning restore CS8625 // Non è possibile convertire il valore letterale Null in tipo riferimento che non ammette i valori Null.
#pragma warning restore CS8631 // Non è possibile usare il tipo come parametro di tipo nel tipo generico o nel metodo. Il supporto dei valori Null dell'argomento tipo non corrisponde al tipo di vincolo.
        }

        [TestMethod()]
        public void IfSuccessFailsWithFailureResult()
        {
            var counter = 0;
            var result = OperationResult
                .MakeFailure(ErrorMessage.Create("ERROR"))
                .IfSuccess(res => counter++);
            Assert.IsFalse(result.Success);
            Assert.IsTrue(counter == 0);
        }

        [TestMethod()]
        public void IfSuccessOfTExecuteCorrectly()
        {
            var counter = 0;
            var result = OperationResult<int>.MakeSuccess(1);
            var result2 = result.IfSuccess(res => counter++);
            Assert.IsTrue(result2.Success);
            Assert.AreEqual(result2.Value, 1);
            Assert.IsTrue(counter == 1);
        }

        [TestMethod()]
        public void IfSuccessOfTFailsWithFailureResult()
        {
            var counter = 0;
            var result = OperationResult<int>
                .MakeFailure(ErrorMessage.Create("ERROR"))
                .IfSuccess(res => counter++);
            Assert.IsFalse(result.Success);
            Assert.IsTrue(counter == 0);
        }

        [TestMethod()]
        public void IfSuccessOfTFailsWithNullArguments()
        {
            OperationResult<int>? result = null;
#pragma warning disable CS8625 // Non è possibile convertire il valore letterale Null in tipo riferimento che non ammette i valori Null.
#pragma warning disable CS8631 // Non è possibile usare il tipo come parametro di tipo nel tipo generico o nel metodo. Il supporto dei valori Null dell'argomento tipo non corrisponde al tipo di vincolo.
            Assert.ThrowsException<ArgumentNullException>(() => result.IfSuccess(null));
            Assert.ThrowsException<ArgumentNullException>(() => result.IfSuccess(res => { }));
            result = OperationResult<int>.MakeSuccess(1);
            Assert.ThrowsException<ArgumentNullException>(() => result.IfSuccess(null));
#pragma warning restore CS8631 // Non è possibile usare il tipo come parametro di tipo nel tipo generico o nel metodo. Il supporto dei valori Null dell'argomento tipo non corrisponde al tipo di vincolo.
#pragma warning restore CS8625 // Non è possibile convertire il valore letterale Null in tipo riferimento che non ammette i valori Null.
        }

        [TestMethod()]
        public void IfSuccessThenReturnTest()
        {
            var result = OperationResult
                .MakeSuccess()
                .IfSuccessThenReturn(() => 10);
            Assert.IsTrue(result.Success);
            Assert.AreEqual(result.Value, 10);
        }

        [TestMethod()]
        public void IfSuccessThenOfTReturnTest()
        {
            var result = OperationResult<int>
                .MakeSuccess(1)
                .IfSuccessThenReturn(() => 10);
            Assert.IsTrue(result.Success);
            Assert.AreEqual(result.Value, 10);
        }

        [TestMethod()]
        public void IfFailedExecutesCorrectly()
        {
            var counter = 0;
            var result = OperationResult
                .MakeFailure(ErrorMessage.Create("ERROR"))
                .IfFailed(res => counter++);
            Assert.IsFalse(result.Success);
            Assert.IsTrue(counter == 1);
        }

        [TestMethod]
        public void IfFailedFailsWithNullArguments()
        {
            OperationResult? result = null;
#pragma warning disable CS8631 // Non è possibile usare il tipo come parametro di tipo nel tipo generico o nel metodo. Il supporto dei valori Null dell'argomento tipo non corrisponde al tipo di vincolo.
#pragma warning disable CS8625 // Non è possibile convertire il valore letterale Null in tipo riferimento che non ammette i valori Null.
            Assert.ThrowsException<ArgumentNullException>(() => result.IfFailed(null));
            Assert.ThrowsException<ArgumentNullException>(() => result.IfFailed(res => { }));
            result = OperationResult.MakeSuccess();
            Assert.ThrowsException<ArgumentNullException>(() => result.IfFailed(null));
#pragma warning restore CS8625 // Non è possibile convertire il valore letterale Null in tipo riferimento che non ammette i valori Null.
#pragma warning restore CS8631 // Non è possibile usare il tipo come parametro di tipo nel tipo generico o nel metodo. Il supporto dei valori Null dell'argomento tipo non corrisponde al tipo di vincolo.
        }

        [TestMethod()]
        public void IfFailedFailsWithSuccessResult()
        {
            var counter = 0;
            var result = OperationResult
                .MakeSuccess()
                .IfFailed(res => counter++);
            Assert.IsTrue(result.Success);
            Assert.IsTrue(counter == 0);
        }

        [TestMethod()]
        public void IfFailedOfTExecutesCorrectly()
        {
            var counter = 0;
            var result = OperationResult<int>
                .MakeFailure(ErrorMessage.Create("ERROR"))
                .IfFailed(res => counter++);
            Assert.IsFalse(result.Success);
            Assert.IsTrue(counter == 1);
        }

        [TestMethod]
        public void IfFailedOfTFailsWithNullArguments()
        {
            OperationResult<int>? result = null;
#pragma warning disable CS8631 // Non è possibile usare il tipo come parametro di tipo nel tipo generico o nel metodo. Il supporto dei valori Null dell'argomento tipo non corrisponde al tipo di vincolo.
#pragma warning disable CS8625 // Non è possibile convertire il valore letterale Null in tipo riferimento che non ammette i valori Null.
            Assert.ThrowsException<ArgumentNullException>(() => result.IfFailed(null));
            Assert.ThrowsException<ArgumentNullException>(() => result.IfFailed(res => { }));
            result = OperationResult<int>.MakeFailure(ErrorMessage.Create("ERROR"));
            Assert.ThrowsException<ArgumentNullException>(() => result.IfFailed(null));
#pragma warning restore CS8625 // Non è possibile convertire il valore letterale Null in tipo riferimento che non ammette i valori Null.
#pragma warning restore CS8631 // Non è possibile usare il tipo come parametro di tipo nel tipo generico o nel metodo. Il supporto dei valori Null dell'argomento tipo non corrisponde al tipo di vincolo.
        }

        [TestMethod()]
        public void IfFailedOfTFailsWithSuccessResult()
        {
            var counter = 0;
            var result = OperationResult<int>
                .MakeSuccess(1)
                .IfFailed(res => counter++);
            Assert.IsTrue(result.Success);
            Assert.IsTrue(counter == 0);
        }

        /*
        [TestMethod()]
        public void ThenTest()
        {
            Assert.Fail("Test to complete");
        }

        [TestMethod()]
        public void ThenTest1()
        {
            Assert.Fail("Test to complete");
        }
        */

        [TestMethod()]
        public void HasErrorsExecutesCorrectly()
        {
            var result = OperationResult.MakeFailure(ErrorMessage.Create("ERROR_CTX","ERROR_DESC"));
            Assert.IsTrue(result.HasErrors("ERROR_CTX", "ERROR_DESC"));
        }

        [TestMethod()]
        public void HasErrorsFailsWithNullArgument()
        {
            OperationResult? result = null;
#pragma warning disable CS8625 // Non è possibile convertire il valore letterale Null in tipo riferimento che non ammette i valori Null.
#pragma warning disable CS8604 // Possibile argomento di riferimento Null.
            Assert.ThrowsException<ArgumentNullException>(() => result.HasErrors(null, null));
            Assert.ThrowsException<ArgumentNullException>(() => result.HasErrors("ERROR_CTX", null));
            Assert.ThrowsException<ArgumentNullException>(() => result.HasErrors(null,"ERROR_DESC"));
#pragma warning restore CS8604 // Possibile argomento di riferimento Null.
#pragma warning restore CS8625 // Non è possibile convertire il valore letterale Null in tipo riferimento che non ammette i valori Null.
        }

        [TestMethod()]
        public void HasErrorsFailsWithSuccess()
        {
            OperationResult result = OperationResult.MakeSuccess();
            Assert.IsFalse(result.HasErrors("ERROR_CTX", "ERROR_DESC"));
        }

        [TestMethod()]
        public void HasErrorsFailsWhenNotFound()
        {
            var result = OperationResult.MakeFailure(ErrorMessage.Create("ERROR_CTX", "ERROR_DESC"));
            Assert.IsFalse(result.HasErrors("ERROR_CTX2", "ERROR_DESC2"));
            Assert.IsFalse(result.HasErrors("ERROR_CTX", "ERROR_DESC2"));
        }

        [TestMethod()]
        public void HasErrorsByContextExecutesCorrectly()
        {
            var result = OperationResult.MakeFailure(ErrorMessage.Create("ERROR_CTX", "ERROR_DESC"));
            Assert.IsTrue(result.HasErrorsByContext("ERROR_CTX"));
        }

        [TestMethod()]
        public void HasErrorsByContextFailsWithNullArgument()
        {
            OperationResult? result = null;
#pragma warning disable CS8625 // Non è possibile convertire il valore letterale Null in tipo riferimento che non ammette i valori Null.
#pragma warning disable CS8604 // Possibile argomento di riferimento Null.
            Assert.ThrowsException<ArgumentNullException>(() => result.HasErrorsByContext(null));
#pragma warning restore CS8604 // Possibile argomento di riferimento Null.
#pragma warning restore CS8625 // Non è possibile convertire il valore letterale Null in tipo riferimento che non ammette i valori Null.
        }

        [TestMethod()]
        public void HasErrorsByContextFailsWithSuccess()
        {
            OperationResult result = OperationResult.MakeSuccess();
            Assert.IsFalse(result.HasErrorsByContext("ERROR_CTX"));
        }

        [TestMethod()]
        public void HasErrorsByContextFailsWhenNotFound()
        {
            var result = OperationResult.MakeFailure(ErrorMessage.Create("ERROR_CTX", "ERROR_DESC"));
            Assert.IsFalse(result.HasErrorsByContext("ERROR_CTX2"));
        }

        [TestMethod()]
        public void HasErrorsByDescriptionExecutesCorrectly()
        {
            var result = OperationResult.MakeFailure(ErrorMessage.Create("ERROR_CTX", "ERROR_DESC"));
            Assert.IsTrue(result.HasErrorsByDescription("ERROR_DESC"));
        }

        [TestMethod()]
        public void HasErrorsByDescriptionFailsWithNullArgument()
        {
            OperationResult? result = null;
#pragma warning disable CS8625 // Non è possibile convertire il valore letterale Null in tipo riferimento che non ammette i valori Null.
#pragma warning disable CS8604 // Possibile argomento di riferimento Null.
            Assert.ThrowsException<ArgumentNullException>(() => result.HasErrorsByDescription(null));
#pragma warning restore CS8604 // Possibile argomento di riferimento Null.
#pragma warning restore CS8625 // Non è possibile convertire il valore letterale Null in tipo riferimento che non ammette i valori Null.
        }

        [TestMethod()]
        public void HasErrorsByDescriptionFailsWithSuccess()
        {
            OperationResult result = OperationResult.MakeSuccess();
            Assert.IsFalse(result.HasErrorsByDescription("ERROR_DESC"));
        }

        [TestMethod()]
        public void HasErrorsByDescriptionFailsWhenNotFound()
        {
            var result = OperationResult.MakeFailure(ErrorMessage.Create("ERROR_CTX", "ERROR_DESC"));
            Assert.IsFalse(result.HasErrorsByDescription("ERROR_DESC2"));
        }
    }
}