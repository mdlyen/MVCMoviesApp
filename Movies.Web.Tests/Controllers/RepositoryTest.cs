using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Movies.Web.Controllers.api;
using Movies.Web.DTO;
using Movies.Web.Services;

namespace Movies.Web.Tests.Controllers
{
    [TestClass]
    public class RepositoryTest
    {
        [TestMethod]
        public void InitialRepositoryTest()
        {
            // Arrange
            var mockRespository = new Mock<IMovieRepository>();
            mockRespository.Setup(x => x.GetAllFilms()).Returns(CreateFullTestList());

            // Act
            var temp = mockRespository.Object.GetAllFilms();

            // Assert
            Assert.AreEqual(temp.Count(), CreateFullTestList().Count());
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
    }
}
