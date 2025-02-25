namespace Validator.Tests
{
    [TestClass()]
    public class MyValidatorTests
    {
        private MyValidator validator = null!;

        [TestInitialize]
        public void Setup()
        {
            validator = new MyValidator();
        }

        [TestMethod()]
        public void ValidateFirstNameTest()
        {
            // Happy paths
            Assert.IsTrue(validator.ValidateFirstName("John"));
            Assert.IsTrue(validator.ValidateFirstName("Alice"));

            // Non happy paths
            Assert.IsFalse(validator.ValidateFirstName("john")); // lowercase first letter
            Assert.IsFalse(validator.ValidateFirstName("John123")); // contains digits
            Assert.IsFalse(validator.ValidateFirstName("")); // empty string
        }

        [TestMethod()]
        public void ValidateSirNameTest()
        {
            // Happy paths
            Assert.IsTrue(validator.ValidateSirName("Doe"));
            Assert.IsTrue(validator.ValidateSirName("Smith"));

            // Non happy paths
            Assert.IsFalse(validator.ValidateSirName("doe")); // lowercase first letter
            Assert.IsFalse(validator.ValidateSirName("Doe123")); // contains digits
            Assert.IsFalse(validator.ValidateSirName("")); // empty string
        }

        [TestMethod()]
        public void ValidateStreetTest()
        {
            // Happy paths
            Assert.IsTrue(validator.ValidateStreet("Main"));
            Assert.IsTrue(validator.ValidateStreet("Broadway"));

            // Non happy paths
            Assert.IsFalse(validator.ValidateStreet("main")); // lowercase first letter
            Assert.IsFalse(validator.ValidateStreet("Main123")); // contains digits
            Assert.IsFalse(validator.ValidateStreet("")); // empty string
        }

        [TestMethod()]
        public void ValidateStreeNumberTest()
        {
            // Happy paths
            Assert.IsTrue(validator.ValidateStreeNumber("123"));
            Assert.IsTrue(validator.ValidateStreeNumber("1A"));
            Assert.IsTrue(validator.ValidateStreeNumber("999 B"));

            // Non happy paths
            Assert.IsFalse(validator.ValidateStreeNumber("1000")); // more than 3 digits
            Assert.IsFalse(validator.ValidateStreeNumber("")); // empty string
        }

        [TestMethod()]
        public void ValidatePostalZipTest()
        {
            // Happy paths
            Assert.IsTrue(validator.ValidatePostalZip("1234"));
            Assert.IsTrue(validator.ValidatePostalZip("5678"));

            // Non happy paths
            Assert.IsFalse(validator.ValidatePostalZip("123")); // less than 4 digits
            Assert.IsFalse(validator.ValidatePostalZip("12345")); // more than 4 digits
            Assert.IsFalse(validator.ValidatePostalZip("abcd")); // non-digit characters
            Assert.IsFalse(validator.ValidatePostalZip("")); // empty string
        }

        [TestMethod()]
        public void ValidatePostalCityTest()
        {
            // Happy paths
            Assert.IsTrue(validator.ValidatePostalCity("NewYork"));
            Assert.IsTrue(validator.ValidatePostalCity("LosAngeles"));

            // Non happy paths
            Assert.IsFalse(validator.ValidatePostalCity("New York")); // contains space
            Assert.IsFalse(validator.ValidatePostalCity("NewYork123")); // contains digits
            Assert.IsFalse(validator.ValidatePostalCity("")); // empty string
        }

        [TestMethod()]
        public void ValidatePhoneNrTest()
        {
            // Happy paths
            Assert.IsTrue(validator.ValidatePhoneNr("12345678"));
            Assert.IsTrue(validator.ValidatePhoneNr("+4512345678"));
            Assert.IsTrue(validator.ValidatePhoneNr("+45 12345678"));

            // Non happy paths
            Assert.IsFalse(validator.ValidatePhoneNr("1234567")); // less than 8 digits
            Assert.IsFalse(validator.ValidatePhoneNr("123456789")); // more than 8 digits
            Assert.IsFalse(validator.ValidatePhoneNr("abcdefgh")); // non-digit characters
            Assert.IsFalse(validator.ValidatePhoneNr("")); // empty string
        }

        [TestMethod()]
        public void ValidateEmailTest()
        {
            // Happy paths
            Assert.IsTrue(validator.ValidateEmail("test@example.com"));
            Assert.IsTrue(validator.ValidateEmail("user.name+tag+sorting@example.com"));

            // Non happy paths
            Assert.IsFalse(validator.ValidateEmail("plainaddress")); // missing '@' and domain
            Assert.IsFalse(validator.ValidateEmail("@missingusername.com")); // missing username
            Assert.IsFalse(validator.ValidateEmail("username@.com")); // missing domain name
            Assert.IsFalse(validator.ValidateEmail("username@com")); // missing top-level domain
            Assert.IsFalse(validator.ValidateEmail("")); // empty string
        }
    }
}