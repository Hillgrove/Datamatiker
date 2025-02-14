
namespace SchoolLibValidatorUnitTest.Tests
{
    [TestClass()]
    public class TeacherTests
    {
        private ITeacher teacher = new Teacher { Id = 1, Name = "A", Salary = 1, Classes = new List<string> { "A" } };
        private ITeacher teacherSalaryZero = new Teacher { Id = 4, Name = "A", Salary = -1, Classes = new List<string> { "A" } };
        private ITeacher teacherListNull = new Teacher { Id = 4, Name = "A", Salary = -1, Classes = null };

     
        [TestMethod()]
        public void ValidateSalaryTest()
        {
            teacher.ValidateSalary();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => teacherSalaryZero.ValidateSalary());
        }

        [TestMethod()]
        public void ValidateTest()
        {
            teacher.Validate();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => teacherSalaryZero.ValidateSalary());
        }

        [TestMethod()]
        [DataRow(1)]  // on boundary
        [DataRow(2)]  // just above boundary
        [DataRow(10000)]  // just a big number

        public void ValidateSalaries(int salary)
        {
            teacher.Salary = salary;
            teacher.ValidateSalary();
        }

        [TestMethod()]
        public void ValidateClassesTest()
        {
            teacher.ValidateClasses();
            Assert.ThrowsException<ArgumentNullException>(() => teacherListNull.ValidateClasses());
        }

        [TestMethod()]
        public void ToStringTest()
        {
            // Arrange
            string expected = "1: A - Salary: 1";

            // Act
            string actual = teacher.ToString();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}