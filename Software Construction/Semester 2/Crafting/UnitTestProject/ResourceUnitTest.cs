
namespace UnitTestProject
{
    [TestClass]
    public class ResourceUnitTest
    {
        [TestMethod]
        public void ValidateString_ValidName_DoesNotThrowException()
        {
            // Arrange
            string validString = "Oak Logs";

            // Act
            Resource testResource = new Resource(validString);

            // Assert
            Assert.IsNotNull(testResource, "Resource object should not be null.");
            Assert.AreEqual(validString.Trim().ToTitleCase(), testResource.Name, "Resource name should be assigned and formatted correctly.");
        }

        [TestMethod]
        public void ValidateString_ValidNonTrimmedName_DoesNotThrowException()
        {
            // Arrange
            string validString = "  OaK lOGs  ";

            // Act
            Resource testResource = new Resource(validString);

            // Assert
            Assert.IsNotNull(testResource, "Resource object should not be null.");
            Assert.AreEqual(validString.Trim().ToTitleCase(), testResource.Name, "Resource name should be assigned and formatted correctly.");
        }

        [TestMethod]
        public void ValidateName_EmptyName_ThrowsArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => { Resource testResource = new Resource(""); });
        }

        [TestMethod]
        public void ValidateString_NullName_ThrowsArgumentNullException()
        {

            Assert.ThrowsException<ArgumentNullException>(() => { Resource testResource = new Resource(null); });
        }

        [TestMethod]
        public void ValidateString_TooShortName_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => { Resource testResource = new Resource("a"); });
        }
    }
}

