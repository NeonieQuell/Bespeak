using Bespeak.DataAccess.Repositories.Base;
using Bespeak.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Bespeak.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRoomRepository _roomRepository;

        public HomeController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<ActionResult> Index()
        {
            (int totalRoomsCount, int availableRoomsCount, int occupiedRoomsCount) =
                await _roomRepository.GetRoomsCountAsync();

            var viewModel = new DashboardViewModel()
            {
                TotalRoomsCount = totalRoomsCount
            };

            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}