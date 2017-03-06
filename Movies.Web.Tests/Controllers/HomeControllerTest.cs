using System.Web.Mvc;
using Movies.Web.Controllers;
using NUnit.Framework;

namespace Movies.Web.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        [Test]
        public void Index()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.That(result != null);
        }
    }
}
