using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Assert.ThrowsException<ArgumentNullException>(() => ErrorMessage.Create(null));
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
            Assert.ThrowsException<ArgumentNullException>(() => ErrorMessage.Create(null, "description"));
            Assert.ThrowsException<ArgumentNullException>(() => ErrorMessage.Create("context", null));
            Assert.ThrowsException<ArgumentNullException>(() => ErrorMessage.Create(null, null));
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
            object otherError = new object();
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
