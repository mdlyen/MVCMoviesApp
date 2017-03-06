using System.Collections.Generic;
using System.Linq;
using Moq;
using Movies.Web.DTO;
using Movies.Web.Models;
using Movies.Web.Services;
using Movies.Web.Tests.Fakes;
using NUnit.Framework;

namespace Movies.Web.Tests.Controllers
{
    [TestFixture]
    public class RepositoryTest
    {
        private static Mock<IMovieRepository> _mockRespository;

        [SetUp]
        public void Init()
        {
            // Test of MOQ.  This isn't a great test however, since I'm only testing the MOQ and not any user code.
            _mockRespository = new Mock<IMovieRepository>();
            _mockRespository.Setup(x => x.GetAllFilms()).Returns(CreateFullTestList());
            _mockRespository.Setup(x => x.GetFilmDTO(It.IsAny<int>())).Returns((int filmid) => PullSingleFilm(filmid));
        }
        
        [Test]
        public void TestGetAllFilms()
        {
            // Arrange

            // Act
            var temp = _mockRespository.Object.GetAllFilms();

            // Assert
            Assert.That(temp.Count() == CreateFullTestList().Count());
        }


        [TestCase(1)]
        [TestCase(2)]
        public void TestSingleFilm(int filmid)
        {
            // Arrange

            // Act
            var temp = _mockRespository.Object.GetFilmDTO(filmid);

            // Assert
            Assert.That(temp.Id == filmid);
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

        private static FilmDTO PullSingleFilm(int filmid)
        {
            var temp = CreateFullTestList();
                
            return temp.First(x => x.Id == filmid);
        }
    }
}
