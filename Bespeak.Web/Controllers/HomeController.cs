using Bespeak.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Bespeak.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("[action]")]
        public IActionResult Rooms()
        {
            return View();
        }

        [Route("[action]")]
        public IActionResult Bookings()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}