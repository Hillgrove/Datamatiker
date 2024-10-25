
namespace Opgave1.Tests
{
    [TestClass()]
    public class TrophyTests
    {
        private Trophy trophyGood = new();

        [TestInitialize]
        public void Setup()
        {
            trophyGood = new Trophy
            {
                Id = 1,
                Competition = "World Cup",
                Year = 1998
            };
        }

        #region ToString Tests
        [TestMethod()]
        public void ToString_WhenCalled_ReturnsFormattedString()
        {
            // Arrange
            string expected = "Id: 1, Competition: World Cup, Year: 1998";

            // Act
            string actual = trophyGood.ToString();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region ValidateCompetition Tests
        [TestMethod()]
        public void ValidateCompetition_WhenCompetitionIsNull_ThrowsArgumentException()
        {
            // Arrange
            trophyGood.Competition = null;

            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() => trophyGood.ValidateCompetition());
        }

        [TestMethod()]
        public void ValidateCompetition_WhenCompetitionIsEmpty_ThrowsArgumentException()
        {
            // Arrange
            trophyGood.Competition = "";

            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() => trophyGood.ValidateCompetition());
        }

        [TestMethod()]
        public void ValidateCompetition_WhenCompetitionIsWhiteSpace_ThrowsArgumentException()
        {
            // Arrange
            trophyGood.Competition = " ";

            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() => trophyGood.ValidateCompetition());
        }

        [TestMethod()]
        public void ValidateCompetition_WhenCompetitionIsTooShort_ThrowsArgumentException()
        {
            // Arrange
            trophyGood.Competition = "ab";

            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() => trophyGood.ValidateCompetition());
        }

        [TestMethod()]
        public void ValidateCompetition_WhenCompetitionIsValid_DoesNotThrowException()
        {
            // Act and Assert
            trophyGood.ValidateCompetition();
        }

        [TestMethod()]
        public void ValidateCompetition_WhenCompetitionIsMinimumValidLength_DoesNotThrowException()
        {
            // Arrange
            trophyGood.Competition = "abc";

            // Act and Assert
            trophyGood.ValidateCompetition();
        }
        #endregion

        #region ValidateYear Tests
        [TestMethod()]
        public void ValidateYear_WhenYearIsOutsideLowerBounds_ThrowsArgumentException()
        {
            // Arrange
            trophyGood.Year = 1969;

            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() => trophyGood.ValidateYear());
        }

        [TestMethod()]
        public void ValidateYear_WhenYearIsOutsideUpperBounds_ThrowsArgumentException()
        {
            // Arrange
            trophyGood.Year = 2025;

            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() => trophyGood.ValidateYear());
        }

        [TestMethod()]
        public void ValidateYear_WhenYearIsOnLowerBounds_DoesNotThrowException()
        {
            // Arrange
            trophyGood.Year = 1970;

            // Act and Assert
            trophyGood.ValidateYear();
        }

        [TestMethod()]
        public void ValidateYear_WhenYearIsOnUpperBounds_DoesNotThrowException()
        {
            // Arrange
            trophyGood.Year = 2024;

            // Act and Assert
            trophyGood.ValidateYear();
        }

        [TestMethod()]
        public void ValidateYear_WhenYearIsWithinBounds_DoesNotThrowException()
        {
            // Act and Assert
            trophyGood.ValidateYear();
        }

        #endregion

        #region Validate Tests
        [TestMethod()]
        public void ValidateTest()
        {
            trophyGood.Validate();
        }
        #endregion
    }
}