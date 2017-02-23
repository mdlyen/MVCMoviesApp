using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Movies.Web.DTO;
using Movies.Web.Services;

namespace Movies.Web.Tests.Controllers
{
    [TestClass]
    public class RepositoryTest
    {
        [TestMethod]
        public void TestGetAllFilms()
        {
            // Arrange
            var mockRespository = CreateMockRepository();

            // Act
            var temp = mockRespository.Object.GetAllFilms();

            // Assert
            Assert.AreEqual(temp.Count(), CreateFullTestList().Count());
        }

        private static Mock<IMovieRepository> CreateMockRepository()
        {
            var mockRespository = new Mock<IMovieRepository>();
            mockRespository.Setup(x => x.GetAllFilms()).Returns(CreateFullTestList());
            mockRespository.Setup(x => x.GetFilmDTO(It.IsAny<int>())).Returns(CreateSingleTestItem);
            return mockRespository;
        }

        [TestMethod]
        public void TestSingleFilm()
        {
            // Arrange
            var mockRespository = CreateMockRepository();

            // Act
            var temp = mockRespository.Object.GetFilmDTO(1);

            // Assert
            Assert.AreEqual(temp.Id, 1);
        }

        private static IEnumerable<FilmDTO> CreateFullTestList()
        {
            var returnList = new List<FilmDTO>();

            var newItem = new FilmDTO
            {
                Id = 1,
                Director = "Director",
                ReleaseYear = "2000",
                Title = "Title"
            };
            returnList.Add(newItem);

            newItem = new FilmDTO
            {
                Id = 2,
                Director = "Director2",
                ReleaseYear = "2001",
                Title = "Title2"
            };
            returnList.Add(newItem);

            return returnList;
        }

        private static FilmDTO CreateSingleTestItem()
        {
            return new FilmDTO
            {
                Id = 1,
                Director = "Director",
                ReleaseYear = "2000",
                Title = "Title"
            };
        }
    }
}
