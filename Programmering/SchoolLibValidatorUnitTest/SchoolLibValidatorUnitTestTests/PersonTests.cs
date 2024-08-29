
namespace SchoolLibValidatorUnitTest.Tests
{
    [TestClass()]
    public class PersonTests
    {
        private Person person = new Person { Id = 1, Name = "A" };
        private Person personNameNull = new Person { Id = 2, Name = null };
        private Person personNameEmpty = new Person { Id = 3, Name = "" };

        [TestMethod()]
        public void ValidateNameTest()
        {
            person.ValidateName();
            Assert.ThrowsException<ArgumentNullException>(() => personNameNull.ValidateName());
            Assert.ThrowsException<ArgumentNullException>(() => personNameEmpty.ValidateName());
        }

        [TestMethod()]
        public void ValidateTest()
        {
            person.Validate();
            Assert.ThrowsException<ArgumentNullException>(() => personNameNull.Validate());
            Assert.ThrowsException<ArgumentNullException>(() => personNameEmpty.Validate());
        }


        [TestMethod()]
        public void ToStringTest()
        {
            // Arrange
            string expected = "1: A";

            // Act
            string actual = person.ToString();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}