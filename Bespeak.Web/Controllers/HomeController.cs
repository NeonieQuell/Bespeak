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
        private readonly IMapper mapper;
        private readonly IRoomRepository roomRepository;
        private readonly IReservationRepository reservationRepository;

        public HomeController(IMapper mapper, IRoomRepository roomRepository, IReservationRepository reservationRepository)
        {
            this.mapper = mapper;
            this.roomRepository = roomRepository;
            this.reservationRepository = reservationRepository;
        }

        public async Task<ActionResult> Index()
        {
            (int total, int available, int occupied) = await this.roomRepository.GetAllCountsAsync();

            var reservationsFromDb = await this.reservationRepository.GetRecentReservationsAsync();
            var reservations = this.mapper.Map<List<ReservationDto>>(reservationsFromDb);

            return View(new DashboardViewModel()
            {
                TotalRooms = total,
                AvailableRooms = available,
                OccupiedRooms = occupied,
                Reservations = reservations
            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}