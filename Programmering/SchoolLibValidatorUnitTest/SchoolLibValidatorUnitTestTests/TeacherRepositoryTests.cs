

namespace SchoolLibValidatorUnitTest.Tests
{
    [TestClass()]
    public class TeacherRepositoryTests
    {
        [TestMethod()]
        public void AddTeacherTest()
        {
            // Arrange
            TeacherRepository repository = new TeacherRepository();
            Teacher teacher = new Teacher() { Name = "Lars", Salary = 1 };
            Teacher teacher2 = new Teacher() { Name = "Jens", Salary = 2 };

            // Act
            Teacher addedTeacher = repository.AddTeacher(teacher);
            Teacher addedTeacher2 = repository.AddTeacher(teacher2);

            // Assert
            Assert.AreEqual(teacher, repository.Get(1));
            Assert.AreEqual(1, addedTeacher.Id);
            Assert.AreEqual(2, addedTeacher2.Id);
        }

        [TestMethod()]
        public void GetTest()
        {
            // Arrange
            TeacherRepository repository = new TeacherRepository();
            Teacher teacher = new Teacher() { Name = "Jens", Salary = 1 };

            // Act
            Teacher addedTeacher = repository.AddTeacher(teacher);

            // Assert
            Assert.AreEqual(addedTeacher.Id, repository.Get(1).Id);
            Assert.IsNotNull(addedTeacher);
        }

        [TestMethod()]
        public void GetTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateTest()
        {
            Assert.Fail();
        }
    }
}