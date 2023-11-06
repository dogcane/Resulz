using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Resulz.UnitTest
{
    [TestClass()]
    public class ErrorMessageTests
    {
        [TestMethod()]
        public void Create_With_Description()
        {
            var error = ErrorMessage.Create("description");
            Assert.AreEqual(String.Empty, error.Context);
            Assert.AreEqual("description", error.Description);
        }

        [TestMethod()]
        public void Create_With_Null_Description()
        {
#pragma warning disable CS8625 // Non è possibile convertire il valore letterale Null in tipo riferimento che non ammette i valori Null.
            Assert.ThrowsException<ArgumentNullException>(() => ErrorMessage.Create(null));
#pragma warning restore CS8625 // Non è possibile convertire il valore letterale Null in tipo riferimento che non ammette i valori Null.
        }

        [TestMethod()]
        public void Create_With_Context_And_Description()
        {
            var error = ErrorMessage.Create("context", "description");
            Assert.AreEqual("context", error.Context);
            Assert.AreEqual("description", error.Description);
        }

        [TestMethod()]
        public void Create_With_Null_Values()
        {
#pragma warning disable CS8625 // Non è possibile convertire il valore letterale Null in tipo riferimento che non ammette i valori Null.
            Assert.ThrowsException<ArgumentNullException>(() => ErrorMessage.Create(null, "description"));
            Assert.ThrowsException<ArgumentNullException>(() => ErrorMessage.Create("context", null));
            Assert.ThrowsException<ArgumentNullException>(() => ErrorMessage.Create(null, null));
#pragma warning restore CS8625 // Non è possibile convertire il valore letterale Null in tipo riferimento che non ammette i valori Null.
        }

        [TestMethod()]
        public void Equals_With_Same_Object()
        {
            var error = ErrorMessage.Create("context", "description");
            object otherError = ErrorMessage.Create("context", "description");
            Assert.IsTrue(error.Equals(otherError));
        }

        [TestMethod()]
        public void Equals_With_Different_Object()
        {
            var error = ErrorMessage.Create("context", "description");
            object otherError = ErrorMessage.Create("context1", "description1");
            Assert.IsFalse(error.Equals(otherError));
        }

        [TestMethod()]
        public void Equals_With_Wrong_Object()
        {
            var error = ErrorMessage.Create("context", "description");
            object otherError = new();
            Assert.ThrowsException<ArgumentException>(() => error.Equals(otherError));
        }

        [TestMethod()]
        public void Equals_With_Null_Object()
        {
            var error = ErrorMessage.Create("context", "description");
            Assert.IsFalse(error.Equals(null));
        }

        [TestMethod()]
        public void Equals_With_Same_Error()
        {
            var error = ErrorMessage.Create("context", "description");
            var otherError = ErrorMessage.Create("context", "description");
            Assert.IsTrue(error.Equals(otherError));
        }

        [TestMethod()]
        public void Equals_With_Different_Error()
        {
            var error = ErrorMessage.Create("context", "description");
            var otherError = ErrorMessage.Create("context1", "description1");
            Assert.IsFalse(error.Equals(otherError));
        }

        [TestMethod()]
        public void GetHashCode_Execution()
        {
            var error = ErrorMessage.Create("context", "description");
            Assert.AreEqual(HashCode.Combine("context", "description"), error.GetHashCode());
        }

        [TestMethod()]
        public void ToString_Execution()
        {
            var error = ErrorMessage.Create("context", "description");
            Assert.AreEqual("context : description", error.ToString());
        }
    }
}
