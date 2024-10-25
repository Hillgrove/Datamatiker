
namespace Opgave1.Tests
{
    [TestClass()]
    public class TrophiesRepositoryTests
    {
        private TrophiesRepository trophyRepo = new();
        private readonly Trophy badTrophy = new Trophy { Id = 0, Competition = "Bad Trophy", Year = 1969 };

    [TestInitialize]
        public void Setup()
        {
            trophyRepo.Add(new Trophy { Id = 1, Competition = "World Cup",          Year = 1998 });
            trophyRepo.Add(new Trophy { Id = 2, Competition = "Champions League",   Year = 2020 });
            trophyRepo.Add(new Trophy { Id = 3, Competition = "Copa America",       Year = 2016 });
            trophyRepo.Add(new Trophy { Id = 4, Competition = "Euro Cup",           Year = 2004 });
            trophyRepo.Add(new Trophy { Id = 5, Competition = "Olympics",           Year = 2008 });
        }

        #region Get Tests
        [TestMethod()]
        public void Get_WithNoParameters_ReturnsEntireList()
        {
            // Arrange
            List<Trophy> expected = new List<Trophy>
            {
                new Trophy { Id = 1, Competition = "World Cup",          Year = 1998 },
                new Trophy { Id = 2, Competition = "Champions League",   Year = 2020 },
                new Trophy { Id = 3, Competition = "Copa America",       Year = 2016 },
                new Trophy { Id = 4, Competition = "Euro Cup",           Year = 2004 },
                new Trophy { Id = 5, Competition = "Olympics",           Year = 2008 }
            };

            // Act
            List<Trophy> actual = trophyRepo.Get();
            
            // Assert
            Assert.AreEqual(5, actual.Count);
            
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, actual[i].Id);
                Assert.AreEqual(expected[i].Competition, actual[i].Competition);
                Assert.AreEqual(expected[i].Year, actual[i].Year);
            }
        }

        [TestMethod()]
        public void Get_BeforeYear2016_ReturnsTrophiesBefore2016()
        {
            // Arrange
            List<Trophy> expected = new List<Trophy>
            {
                new Trophy { Id = 1, Competition = "World Cup",          Year = 1998 },
                new Trophy { Id = 4, Competition = "Euro Cup",           Year = 2004 },
                new Trophy { Id = 5, Competition = "Olympics",           Year = 2008 }
            };

            // Act
            List<Trophy> actual = trophyRepo.Get(beforeYear: 2016);

            // Assert
            Assert.AreEqual(3, actual.Count);

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, actual[i].Id);
                Assert.AreEqual(expected[i].Competition, actual[i].Competition);
                Assert.AreEqual(expected[i].Year, actual[i].Year);
            }
        }

        [TestMethod()]
        public void Get_AfterYear2008_ReturnsTrophiesAfterYear2008()
        {
            // Arrange
            List<Trophy> expected = new List<Trophy>
            {
                new Trophy { Id = 2, Competition = "Champions League",   Year = 2020 },
                new Trophy { Id = 3, Competition = "Copa America",       Year = 2016 }
            };

            // Act
            List<Trophy> actual = trophyRepo.Get(afterYear: 2008);

            // Assert
            Assert.AreEqual(2, actual.Count);

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, actual[i].Id);
                Assert.AreEqual(expected[i].Competition, actual[i].Competition);
                Assert.AreEqual(expected[i].Year, actual[i].Year);
            }
        }

        [TestMethod()]
        public void Get_ExactYear2016_ReturnsTrophiesFrom2016()
        {
            // Arrange
            List<Trophy> expected = new List<Trophy>
            {
                new Trophy { Id = 3, Competition = "Copa America", Year = 2016 }
            };

            // Act
            List<Trophy> actual = trophyRepo.Get(exactYear: 2016);

            // Assert
            Assert.AreEqual(1, actual.Count);

            Assert.AreEqual(expected[0].Id, actual[0].Id);
            Assert.AreEqual(expected[0].Competition, actual[0].Competition);
            Assert.AreEqual(expected[0].Year, actual[0].Year);
        }

        [TestMethod()]
        public void Get_BeforeYear1970_ReturnsEmptyList()
        {
            // Arrange
            List<Trophy> expected = new List<Trophy>();

            // Act
            List<Trophy> actual = trophyRepo.Get(beforeYear: 1970);

            // Assert
            Assert.AreEqual(0, actual.Count);
        }

        [TestMethod()]
        public void Get_AfterYear2024_ReturnsEmptyList()
        {
            // Arrange
            List<Trophy> expected = new List<Trophy>();

            // Act
            List<Trophy> actual = trophyRepo.Get(afterYear: 2024);

            // Assert
            Assert.AreEqual(0, actual.Count);
        }

        [TestMethod()]
        public void Get_ExactYear2015_ReturnsEmptyList()
        {
            // Arrange
            List<Trophy> expected = new List<Trophy>();

            // Act
            List<Trophy> actual = trophyRepo.Get(exactYear: 2015);

            // Assert
            Assert.AreEqual(0, actual.Count);
        }

        [TestMethod()]
        public void Get_OrderByCompetition_ReturnsTrophiesOrderedByCompetition()
        {
            // Arrange
            List<Trophy> expected = new List<Trophy>
            {
                new Trophy { Id = 2, Competition = "Champions League",   Year = 2020 },
                new Trophy { Id = 3, Competition = "Copa America",       Year = 2016 },
                new Trophy { Id = 4, Competition = "Euro Cup",           Year = 2004 },
                new Trophy { Id = 5, Competition = "Olympics",           Year = 2008 },
                new Trophy { Id = 1, Competition = "World Cup",          Year = 1998 }
            };

            // Act
            List<Trophy> actual = trophyRepo.Get(orderBy: "Competition");

            // Assert
            Assert.AreEqual(5, actual.Count);

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, actual[i].Id);
                Assert.AreEqual(expected[i].Competition, actual[i].Competition);
                Assert.AreEqual(expected[i].Year, actual[i].Year);
            }
        }

        [TestMethod()]
        public void Get_OrderByYear_ReturnsTrophiesOrderedByYear()
        {
            // Arrange
            List<Trophy> expected = new List<Trophy>
            {
                new Trophy { Id = 1, Competition = "World Cup",          Year = 1998 },
                new Trophy { Id = 4, Competition = "Euro Cup",           Year = 2004 },
                new Trophy { Id = 5, Competition = "Olympics",           Year = 2008 },
                new Trophy { Id = 3, Competition = "Copa America",       Year = 2016 },
                new Trophy { Id = 2, Competition = "Champions League",   Year = 2020 }
            };

            // Act
            List<Trophy> actual = trophyRepo.Get(orderBy: "Year");

            // Assert
            Assert.AreEqual(5, actual.Count);

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, actual[i].Id);
                Assert.AreEqual(expected[i].Competition, actual[i].Competition);
                Assert.AreEqual(expected[i].Year, actual[i].Year);
            }
        }

        [TestMethod()]
        public void Get_BeforeYear2020_AfterYear2004_OrderByYear_ReturnsTrophiesBefore2020After2008OrderedByYear()
        {
            // Arrange
            List<Trophy> expected = new List<Trophy>
            {
                new Trophy { Id = 5, Competition = "Olympics",           Year = 2008 },
                new Trophy { Id = 3, Competition = "Copa America",       Year = 2016 }
            };

            // Act
            List<Trophy> actual = trophyRepo.Get(beforeYear: 2020, afterYear: 2004, orderBy: "Year");

            // Assert
            Assert.AreEqual(2, actual.Count);

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, actual[i].Id);
                Assert.AreEqual(expected[i].Competition, actual[i].Competition);
                Assert.AreEqual(expected[i].Year, actual[i].Year);
            }
        }

        [TestMethod()]
        public void Get_WithInvalidOrderBy_ThrowsArgumentException()
        {
            // Act
            List<Trophy> actual = trophyRepo.Get(orderBy: "Invalid");

            // Assert
            Assert.AreEqual(5, actual.Count); // Returns entire list unordered

        }
        #endregion

        #region GetById Tests
        [TestMethod()]
        public void GetById_ExistingId_ReturnsTrophy()
        {
            // Arrange
            Trophy expected = new Trophy { Id = 3, Competition = "Copa America", Year = 2016 };

            // Act
            Trophy? actual = trophyRepo.GetById(3);

            // Assert
            Assert.AreEqual(expected.Id, actual?.Id);
        }

        [TestMethod()]
        public void GetById_NonExistingId_ReturnsNull()
        {
            // Arrange
            int notExistingIndex = trophyRepo.Get().Count + 1;
            Trophy? expected = null;

            // Act
            Trophy? actual = trophyRepo.GetById(notExistingIndex);

            // Assert
            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region Add Tests
        [TestMethod()]
        public void Add_ValidTrophy_ReturnsValidTrophy()
        {
            // Arrange
            Trophy expected = new Trophy { Id = 6, Competition = "New Trophy", Year = 2024 };

            // Act
            Trophy actual = trophyRepo.Add(new Trophy { Competition = "New Trophy", Year = 2024 });

            // Assert
            Assert.AreEqual(expected.Id, actual.Id);
        }

        [TestMethod()]
        public void Add_InvalidTrophy_ThrowsArgumentException()
        {
            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() => trophyRepo.Add(badTrophy));
        }
        #endregion

        #region Remove Tests
        [TestMethod()]
        public void Remove_ExistingId_ReturnsValidTrophy()
        {
            // Arrange
            Trophy expected = new Trophy { Id = 3, Competition = "Copa America", Year = 2016 };

            // Act
            Trophy? actual = trophyRepo.Remove(3);

            // Assert
            Assert.AreEqual(expected.Id, actual?.Id);
        }

        [TestMethod()]
        public void Remove_NonExistingId_ReturnsNull()
        {
            // Arrange
            int notExistingIndex = trophyRepo.Get().Count + 1;
            Trophy? expected = null;

            // Act
            Trophy? actual = trophyRepo.Remove(notExistingIndex);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Remove_ExistingId_RemovesTrophyFromList()
        {
            // Arrange
            int idToRemove = 3;
            
            // Act
            Trophy? removedTrophy = trophyRepo.Remove(idToRemove);
            Trophy? retrievedTrophy = trophyRepo.GetById(idToRemove);

            // Assert
            Assert.AreEqual(4, trophyRepo.Get().Count);
            Assert.IsNotNull(removedTrophy);
            Assert.IsNull(retrievedTrophy);
        }
        #endregion

        #region Update Tests
        [TestMethod()]
        public void Update_NotExistingId_ValidTrophy_ReturnsNull()
        {
            // Arrange
            int notExistingIndex = trophyRepo.Get().Count + 1;
            Trophy? expected = null;

            // Act
            Trophy? actual = trophyRepo.Update(notExistingIndex, new Trophy { Competition = "New Trophy", Year = 2024 });

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Update_ExistingId_InvalidTrophy_ThrowsArgumentException()
        {
            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() => trophyRepo.Update(1, badTrophy));
        }

        [TestMethod()]
        public void Update_ExistingId_ValidTrophy_ReturnsUpdatedTrophy()
        {
            // Arrange
            Trophy expected = new Trophy { Id = 1, Competition = "New Trophy", Year = 2024 };

            // Act
            Trophy? actual = trophyRepo.Update(1, new Trophy { Competition = "New Trophy", Year = 2024 });

            // Assert
            Assert.AreEqual(expected.Id, actual?.Id);
            Assert.AreEqual(expected.Competition, actual?.Competition);
            Assert.AreEqual(expected.Year, actual?.Year);
        }
        #endregion
    }
}