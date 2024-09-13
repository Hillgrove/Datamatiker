
namespace ActorRepositoryLib.Tests
{
    [TestClass()]
    public class ActorRepositoryTests
    {
        private ActorRepository actorRepository = null!;
        private readonly Actor actorAdam2000 = new Actor() { Name = "Adam", BirthYear = 2000 };
        private readonly Actor actorBenedict2001 = new Actor() { Name = "Benedict", BirthYear = 2001 };
        private readonly Actor actorChristine2002 = new Actor() { Name = "Christine", BirthYear = 2002 };

        [TestInitialize]
        public void Initialize()
        {
            actorRepository = new ActorRepository();
            actorRepository.Add(actorAdam2000);
            actorRepository.Add(actorBenedict2001);
            actorRepository.Add(actorChristine2002);
        }

        [TestMethod()]

        public void AddTest()
        {
            // Arrange
            Actor newActor = new Actor() { Name = "David", BirthYear = 2003 };
            int actorCountBeforeAdd = actorRepository.Get().Count;

            // Act
            actorRepository.Add(newActor);
            var actorRepoAfterAdd = actorRepository.Get();
            int actorCountAfterAdd = actorRepoAfterAdd.Count;
            
            // Assert
            Assert.AreEqual(actorCountBeforeAdd + 1, actorCountAfterAdd);
            Assert.IsTrue(actorRepoAfterAdd.Contains(newActor));
            Assert.IsNotNull(actorRepoAfterAdd.FirstOrDefault(a => a.Name == newActor.Name && a.BirthYear == newActor.BirthYear));
        }

        [TestMethod()]
        public void GetByIdTest()
        {   

            Assert.Fail();
        }

        [TestMethod()]
        public void GetTest()
        {
            List<Actor> expected = new List<Actor>();
            expected.Add(actorBenedict2001);
            expected.Add(actorChristine2002);

            // Act
            List<Actor> result = actorRepository?.Get(2001) ?? new List<Actor>();

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