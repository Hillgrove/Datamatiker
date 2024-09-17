
namespace ActorRepositoryLib.Tests
{
    [TestClass()]
    public class ActorRepositoryTests
    {
        private ActorRepositoryList<Actor> actorRepository = null!;
        private readonly Actor actorAdam2000 = new Actor() { Name = "Adam", BirthYear = 2000 };
        private readonly Actor actorBenedict2001 = new Actor() { Name = "Benedict", BirthYear = 2001 };
        private readonly Actor actorChristine2002 = new Actor() { Name = "Christine", BirthYear = 2002 };

        [TestInitialize]
        public void Initialize()
        {
            actorRepository = new ActorRepositoryList<Actor>();
            actorRepository.Add(actorAdam2000);
            actorRepository.Add(actorBenedict2001);
            actorRepository.Add(actorChristine2002);
        }

        [TestMethod()]

        public void AddTest()
        {
            // Arrange
            Actor newActor = new Actor() { Name = "David", BirthYear = 2003 };
            int actorCountBeforeAdd = actorRepository.Get().Count();  

            // Act
            actorRepository.Add(newActor);
            var actorRepoAfterAdd = actorRepository.Get();
            int actorCountAfterAdd = actorRepoAfterAdd.Count();

            // Assert
            Assert.AreEqual(actorCountBeforeAdd + 1, actorCountAfterAdd);
            Assert.IsTrue(actorRepoAfterAdd.Contains(newActor));
            Assert.IsNotNull(actorRepoAfterAdd.FirstOrDefault(a => a.Name == newActor.Name && a.BirthYear == newActor.BirthYear));
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            // Arrange
            int ActorIdExisting = actorAdam2000.Id;
            int ActorIdNotExisting = 1000;

            // Act
            Actor? existingActorResult = actorRepository.GetById(ActorIdExisting);
            Actor? notExistingActorResult = actorRepository.GetById(ActorIdNotExisting);

            // Assert
            Assert.AreEqual(actorAdam2000, existingActorResult);
            Assert.IsNull(notExistingActorResult);
        }


        [TestMethod()]
        public void GetTestByName()
        {
            // Arrange
            string name = "Benedict";
            List<Actor> expected = new List<Actor>();
            expected.Add(actorBenedict2001);

            // Act
            List<Actor> result = actorRepository.Get(actor => actor.Name == name).ToList();

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetTestNameNull()
        {
            // Arrange
            string? nullName = null;
            List<Actor> expected = new List<Actor>();
            Actor nullNameActor = new Actor() { Name = null, BirthYear = 1980 };

            // Act
            List<Actor> result = actorRepository.Get(actor => actor.Name == nullName).ToList();

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void GetTestByBirthYear()
        {
            int birthYear = 2001;
            List<Actor> expected = new List<Actor>();
            expected.Add(actorBenedict2001);
            expected.Add(actorChristine2002);

            // Act
            List<Actor> result = actorRepository.Get(actor => actor.BirthYear >= birthYear).ToList();
            // TODO: Why is not only partially tested?

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetTestSortByName()
        {
            // Arrange
            List<Actor> expected = new List<Actor>();
            expected.Add(actorAdam2000);
            expected.Add(actorBenedict2001);
            expected.Add(actorChristine2002);

            // Act
            List<Actor> result = actorRepository.Get(orderBy: q => q.OrderBy(actor => actor.Name)).ToList();

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetTestSortByNameDesc()
        {
            // Arrange
            List<Actor> expected = new List<Actor>();
            expected.Add(actorChristine2002);
            expected.Add(actorBenedict2001);
            expected.Add(actorAdam2000);

            // Act
            List<Actor> result = actorRepository.Get(orderBy: q => q.OrderByDescending(actor => actor.Name)).ToList();

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetTestSortByBirthYear()
        {
            // Arrange
            List<Actor> expected = new List<Actor>();
            expected.Add(actorAdam2000);
            expected.Add(actorBenedict2001);
            expected.Add(actorChristine2002);

            // Act
            List<Actor> result = actorRepository.Get(orderBy: q => q.OrderBy(actor => actor.BirthYear)).ToList();
            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void UpdateTestActorNotNull()
        {
            // Arrange
            Actor actorToUpdate = new Actor() { Name = "David", BirthYear = 2003 };
            int id = actorAdam2000.Id;

            // Act
            Actor? updatedActor = actorRepository.Update(id, actorToUpdate);

            // Arrange
            //Assert.AreEqual(actorToUpdate, updatedActor); // This doesn't work
            //Assert.AreEqual(actorToUpdate.Name, updatedActor?.Name); // works but needs 2 asserts
            //Assert.AreEqual(actorToUpdate.BirthYear, updatedActor?.BirthYear); // works but needs 2 asserts
            Assert.IsTrue(actorToUpdate.Name == updatedActor?.Name && actorToUpdate.BirthYear == updatedActor?.BirthYear);
            // TODO: Why is not only partially tested?
        }

        [TestMethod()]
        public void UpdateTestActorNull()
        {
            // Arrange
            Actor actorToUpdate = new Actor() { Name = "David", BirthYear = 2003 };
            int id = actorRepository.Get().Count() + 1; // Id that doesn't exist

            // Act and Assert
            Assert.ThrowsException<KeyNotFoundException>(() => actorRepository.Update(id, actorToUpdate));
        }

        [TestMethod()]
        public void DeleteTestActorNotNull()
        {

            // Arrange
            Actor actorToDelete = actorAdam2000;
            int id = actorToDelete.Id;
            int length = actorRepository.Get().Count();

            // Act
            Actor? deletedActor = actorRepository.Delete(id);
            var updatedActors = actorRepository.Get();

            // Assert
            Assert.AreEqual(length - 1, updatedActors.Count());
            Assert.AreEqual(actorToDelete, deletedActor);
            Assert.IsFalse(updatedActors.Contains(actorToDelete));
        }

        [TestMethod()]
        public void DeleteTestActorNull()
        {
            // Arrange
            int id = actorRepository.Get().Count() + 1; // Id that doesn't exist
            int length = actorRepository.Get().Count();

            // Act
            Actor? deletedActor = actorRepository.Delete(id);
            var updatedActors = actorRepository.Get();

            // Assert
            Assert.AreEqual(length, updatedActors.Count());
            Assert.IsNull(deletedActor);
        }
    }
}