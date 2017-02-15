using System.Linq;
using System.Web.Mvc;
using Movies.Web.Services;

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
            var rep = new MovieRepository();
            return View(rep.GetAllFilmDTOs());
        }
    }
}