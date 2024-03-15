
namespace UnitTestProject
{
    [TestClass]
    public class ValidatorUnitTest
    {
        [TestMethod]
        public void ValidateString_ValidName_DoesNotThrowException()
        {
            Validator.ValidateString("Aragorn Elessar the 2nd");
        }

        [TestMethod]
        public void ValidateString_ValidNonTrimmedName_DoesNotThrowException()
        {
            Validator.ValidateString("  ArAgOrN     Elessar  ");
        }

        [TestMethod]
        public void ValidateString_EmptyName_ThrowsArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>( () => { Validator.ValidateString(""); });
        }

        [TestMethod]
        public void ValidateString_NullName_ThrowsArgumentNullException()
        {

            Assert.ThrowsException<ArgumentNullException>( () => { Validator.ValidateString(null); });
        }

        [TestMethod]
        public void ValidateString_TooShortName_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>( () => { Validator.ValidateString("a"); });
        }
    }
}