using System.Web.Mvc;

namespace Task.Controllers
{
    public class UniversityController : Controller
    {
        // GET: University
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FirstBuilding()
        {
            return View();
        }

        public ActionResult SecondBuilding()
        {
            return View();
        }
    }
}