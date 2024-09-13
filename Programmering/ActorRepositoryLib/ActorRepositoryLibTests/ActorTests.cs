
namespace ActorRepositoryLib.Tests
{
    [TestClass()]
    public class ActorTests
    {
        private readonly Actor actorGood = new Actor() { Name = "John Doe", BirthYear = 1900 };

        [TestMethod()]
        public void ValidateNameTest()
        {
            // Arrange
            Actor actorValidNameWithFourChars = new Actor() { Name = "John" };
            Actor actorShortName = new Actor() { Name = "Joe" };
            Actor actorNullName = new Actor() { Name = null };

            // Act
            actorGood.ValidateName();
            actorValidNameWithFourChars.ValidateName();
            
            // Assert
            Assert.ThrowsException<ArgumentException>(() => actorShortName.ValidateName());
            Assert.ThrowsException<ArgumentNullException>(() => actorNullName.ValidateName());
            
        }

        [TestMethod()]
        public void ValidateBirthYearTest()
        {
            // Arrange
            Actor actorEarlyBirthYear = new Actor() { BirthYear = 1819 };
            Actor actorCurrentBirthYear = new Actor() { BirthYear = DateTime.Now.Year };
            Actor actorLateBirthYear = new Actor() { BirthYear = DateTime.Now.Year + 1 };

            // Act
            actorGood.ValidateBirthYear();
            actorCurrentBirthYear.ValidateBirthYear();


            // Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => actorEarlyBirthYear.ValidateBirthYear());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => actorLateBirthYear.ValidateBirthYear());

        }

        [TestMethod()]
        public void ValidateTest()
        {
            // Arange

            // Act
            actorGood.Validate();

            // Assert
        }
    }
}