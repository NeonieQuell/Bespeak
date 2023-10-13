using Microsoft.AspNetCore.Mvc;

namespace Bespeak.Web.Controllers
{
    public class BookingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
