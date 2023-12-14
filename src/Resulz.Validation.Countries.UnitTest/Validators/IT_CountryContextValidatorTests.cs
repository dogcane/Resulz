namespace Resulz.Validation.Countries.Validators.UnitTest
{
    [TestClass()]
    public class IT_CountryContextValidatorTests
    {
        [TestMethod()]
        public void IT_CountryContextValidator_Ctor()
        {
            var validator = new IT_CountryContextValidator();
            Assert.IsNotNull(validator);
            Assert.AreEqual(validator.CountryCode, "IT");
        }

        [TestMethod()]
        [DataRow("IT40474690803", true)]
        [DataRow("IT57690380324", true)]
        [DataRow("IT36647720147", true)]
        [DataRow("1234567890", false)]
        [DataRow("IT1234567890", false)]
        [DataRow("IT12345678901", false)]
        [DataRow("IT123456789012", false)]
        [DataRow("A1234567890", false)]
        public void IsVatNumberValidTest(string vatNumber, bool expectedResult)
        {
            var validator = new IT_CountryContextValidator();
            Assert.AreEqual(validator.IsVatNumberValid(vatNumber), expectedResult);
        }

        [TestMethod()]
        [DataRow("ABC1234", true)]
        [DataRow("DEF5678", true)]
        [DataRow("GHI9012", true)]
        [DataRow("AB4567", false)]
        [DataRow("ABCDEF!", false)]
        [DataRow("AB23EFGHI", false)]
        public void IsRecipientCodeValidTest(string recipientCode, bool expectedResult)
        {
            var validator = new IT_CountryContextValidator();
            Assert.AreEqual(validator.IsVatRecipientCodeValid(recipientCode), expectedResult);
        }
    }
}