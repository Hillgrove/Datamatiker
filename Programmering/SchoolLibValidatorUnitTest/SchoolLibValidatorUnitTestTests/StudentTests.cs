
namespace SchoolLibValidatorUnitTest.Tests
{
    [TestClass()]
    public class StudentTests
    {
        private IStudent student = new Student { Id = 1, Name = "A", Semester = 1 };
        private IStudent studentSemesterZero = new Student { Id = 4, Name = "A", Semester = 0 };
        private IStudent studentSemesterEight = new Student { Id = 5, Name = "A", Semester = 8 };

        [TestMethod()]
        public void ValidateSemesterTest()
        {
            student.ValidateSemester();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => studentSemesterZero.ValidateSemester());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => studentSemesterEight.ValidateSemester());
        }

        [TestMethod()]
        public void ValidateTest()
        {
            student.Validate();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => studentSemesterZero.Validate());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => studentSemesterEight.Validate());
        }

        [TestMethod()]
        [DataRow(1)] // On boundary
        [DataRow(2)] // Just above boundary
        [DataRow(6)] // Just under boundary
        [DataRow(7)] // On boundary
        public void ValidateSemesters(int semester)
        {
            student.Semester = semester;
            student.ValidateSemester();
        }

        [TestMethod()]
        public void ToStringTest()
        {
            // Arrange
            string expected = "1: A - Semester: 1";

            // Act
            string actual = student.ToString();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}