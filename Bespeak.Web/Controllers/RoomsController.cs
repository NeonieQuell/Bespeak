using Microsoft.AspNetCore.Mvc;

namespace Bespeak.Web.Controllers
{
    public class RoomsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
