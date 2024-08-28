
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolLibValidatorUnitTest;

namespace SchoolLibValidatorUnitTest.Tests
{
    [TestClass()]
    public class TeacherTests
    {
        private Teacher teacher = new Teacher { Id = 1, Name = "A", Salary = 1 };
        private Teacher teacherNameNull = new Teacher { Id = 2, Name = null, Salary = 1 };
        private Teacher teacherNameEmpty = new Teacher { Id = 3, Name = "", Salary = 1 };
        private Teacher teacherSalaryZero = new Teacher { Id = 4, Name = "A", Salary = -1 };

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
        
        [TestMethod()]
        public void ValidateNameTest()
        {
            teacher.ValidateName();
            Assert.ThrowsException<ArgumentNullException>(() => teacherNameNull.ValidateName());
            Assert.ThrowsException<ArgumentNullException>(() => teacherNameEmpty.ValidateName());
        }

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
            Assert.ThrowsException<ArgumentNullException>(() => teacherNameNull.Validate());
            Assert.ThrowsException<ArgumentNullException>(() => teacherNameEmpty.Validate());
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
    }
}