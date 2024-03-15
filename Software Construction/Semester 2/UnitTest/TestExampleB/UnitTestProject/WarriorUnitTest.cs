
namespace UnitTestProject
{
    [TestClass]
    public class WarriorUnitTest
    {
        [TestMethod]
        public void TestWarrior_Constructor_NameTooShort_Exception()
        {
            // Arrange, Act & Assert
            Assert.ThrowsException<ArgumentException>(() => { Warrior testSubject = new Warrior("A", 100); });
        }

        [TestMethod]
        public void TestWarrior_Constructor_NameWhiteSpace_Exception()
        {
            // Arrange, Act & Assert
            Assert.ThrowsException<ArgumentException>(() => { Warrior testSubject = new Warrior("   ", 100); });
        }

        [TestMethod]
        public void TestWarrior_Constructor_NameIsNull_Exception()
        {
            string? nullString = null;
            // Arrange, Act & Assert
            Assert.ThrowsException<ArgumentException>(() => { Warrior testSubject = new Warrior(nullString, 100); });
        }


        [TestMethod]
        public void TestWarrior_Constructor_HitPointsMinimal_NoException()
        {
            // Act
            Warrior actualResult = new Warrior("Rolf", 1);

            // Assert
            Assert.IsNotNull(actualResult);
        }

        [TestMethod]
        public void TestWarrior_Constructor_HitpointsNegative_Exception()
        {
            // Arrange, Act & Assert
            Assert.ThrowsException<ArgumentException>(() => { Warrior testSubject = new Warrior("A", -1); });
        }

        // why call it GetOnce? is there a difference if it's several gets?
        [TestMethod]
        public void TestWarrior_Name_GetOnce()
        {
            // Arrange
            Warrior testSubject = new Warrior("Rolf", 100);
            string expectedResult = "Rolf";

            // Act
            string actualResult = testSubject.Name;

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestWarrior_HitPoints_GetOnce()
        {
            // Arrange
            Warrior testSubject = new Warrior("Rolf", 100);
            int expectedResult = 100;

            // Act
            int actualResult = testSubject.HitPoints;

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestWarrior_IsDead_GetInitial()
        {
            // Arrange
            Warrior testSubject = new Warrior("Rolf", 100);
            bool expectedResult = false;

            // Act
            bool actualResult = testSubject.IsDead;

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        // Is this rather a RecieveDamage test?
        [TestMethod]
        public void TestWarrior_IsDead_True()
        {
            // Arrange
            Warrior testSubject = new Warrior("Rolf", 100);
            testSubject.ReceiveDamage(100);
            bool expectedResult = true;

            // Act
            bool actualResult = testSubject.IsDead;

            // Assert
            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestMethod]
        public void TestWarrior_ReceiveDamage_DamageNegative_Exception()
        {
            // Arrange
            Warrior testSubject = new Warrior("Rolf", 100);
            
            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => { testSubject.ReceiveDamage(-1); });
        }

        [TestMethod]
        public void TestWarrior_ReceiveDamage_30_70()
        {
            // Arrange
            Warrior testSubject = new Warrior("Rolf", 100);
            testSubject.ReceiveDamage(30);
            int expectedResult = 70;

            // Act
            int actualResult = testSubject.HitPoints;

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}