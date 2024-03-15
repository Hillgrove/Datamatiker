
namespace UnitTestProject
{
    [TestClass]
    public class RecipeUnitTest
    {
        [TestMethod]
        public void ValidateString_ValidName_DoesNotThrowException()
        {
            // Arrange
            string validString = "Elven Longbow";

            // Act
            Recipe testRecipe = new Recipe(validString);

            // Assert
            Assert.IsNotNull(testRecipe, "Recipe name should not be null.");
            Assert.AreEqual(validString.Trim().ToTitleCase(), testRecipe.Name, "Recipe name should be assigned and formatted correctly.");
        }

        [TestMethod]
        public void ValidateString_ValidNonTrimmedName_DoesNotThrowException()
        {
            // Arrange
            string validString = "  ElVeN    LONGbow  ";

            // Act
            Recipe testRecipe = new Recipe(validString);

            // Assert
            Assert.IsNotNull(testRecipe, "Recipe name should not be null.");
            Assert.AreEqual(validString.Trim().ToTitleCase(), testRecipe.Name, "Recipe name should be assigned and formatted correctly.");
        }

        [TestMethod]
        public void ValidateName_EmptyName_ThrowsArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => { Recipe testRecipe = new Recipe(""); });
        }

        [TestMethod]
        public void ValidateString_NullName_ThrowsArgumentNullException()
        {

            Assert.ThrowsException<ArgumentNullException>(() => { Recipe testRecipe = new Recipe(null); });
        }   

        [TestMethod]
        public void ValidateString_TooShortName_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => { Recipe testRecipe = new Recipe("a"); });
        }
    }
}

