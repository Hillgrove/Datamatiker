
using System.Collections.Concurrent;

namespace ActorRepositoryLib.Tests
{
    [TestClass()]
    public class ActorRepositoryTests
    {
        [TestMethod()]
        public void AddTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetTest()
        {
            // Arrange
            Actor actorBirthYear2000 = new Actor() { Name = "John Doe", BirthYear = 2000 };
            Actor actorBirthYear2001 = new Actor() { Name = "John Doe", BirthYear = 2001 };
            Actor actorBirthYear2002 = new Actor() { Name = "John Doe", BirthYear = 2002 };

            ActorRepository actorRepository = new ActorRepository();
            actorRepository.Add(actorBirthYear2000);
            actorRepository.Add(actorBirthYear2001);
            actorRepository.Add(actorBirthYear2002);

            List<Actor> expected = new List<Actor>();
            expected.Add(actorBirthYear2001);
            expected.Add(actorBirthYear2002);

            // Act
            List<Actor> result = actorRepository.Get(2001).ToList();

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.Fail();
        }
    }
}