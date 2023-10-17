using AutoMapper;
using Bespeak.DataAccess.Repositories.Base;
using Bespeak.Web.Models;
using Bespeak.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Bespeak.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRoomRepository _roomRepository;
        private readonly IBookingRepository _bookingRepository;

        #region Constructor
        public HomeController(
            IMapper mapper,
            IRoomRepository roomRepository,
            IBookingRepository bookingRepository)
        {
            _mapper = mapper;
            _roomRepository = roomRepository;
            _bookingRepository = bookingRepository;
        }
        #endregion

        public async Task<ActionResult> Index()
        {
            (int totalRoomsCount, int availableRoomsCount, int occupiedRoomsCount) =
                await _roomRepository.GetRoomsCountAsync();

            var bookingsFromDb = await _bookingRepository.GetRecentBookingsAsync();
            var bookings = _mapper.Map<List<BookingDto>>(bookingsFromDb);

            var viewModel = new DashboardViewModel()
            {
                TotalRoomsCount = totalRoomsCount,
                AvailableRoomsCount = availableRoomsCount,
                OccupiedRoomsCount = occupiedRoomsCount,
                Bookings = bookings
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