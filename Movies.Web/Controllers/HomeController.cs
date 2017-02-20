using System.Web.Mvc;
using Movies.Web.Controllers.api;

namespace Movies.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Films()
        {
            var filmAPI = new FilmsController();
            return View(filmAPI.GetFilms());
        }
    }
}