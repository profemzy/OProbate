using System.Linq;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult DashboardV1()
        {
            ViewBag.Count = _context.Archives.Count();
            return View();
        }
        public ActionResult DashboardV2()
        {
            return View();
        }
    }
}