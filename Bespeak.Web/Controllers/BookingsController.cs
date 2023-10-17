using AutoMapper;
using Bespeak.DataAccess.Repositories.Base;
using Bespeak.Entity.Entities;
using Bespeak.Web.Models;
using Bespeak.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bespeak.Web.Controllers
{
    public class BookingsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRoomRepository _roomRepository;
        private readonly IBookingRepository _bookingRepository;

        #region Constructor
        public BookingsController(
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
            var roomsFromDb = await _roomRepository.GetRoomsAsync();
            var rooms = _mapper.Map<List<RoomDto>>(roomsFromDb);

            var bookingsFromDb = await _bookingRepository.GetBookingsAsync();
            var bookings = _mapper.Map<List<BookingDto>>(bookingsFromDb);

            var viewModel = new BookingsViewModel()
            {
                Rooms = rooms,
                Bookings = bookings
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> CreateBook(BookingDtoForCreate booking)
        {
            var bookingIdResult = await _bookingRepository.AddAsync(_mapper.Map<Booking>(booking));

            return Json(new
            {
                title = "Booked successfully",
                text = $"Your booking ID is: {bookingIdResult}"
            });
        }

        [HttpGet]
        public async Task<ActionResult> GetBooking(string bookingId)
        {
            var bookingFromDb = await _bookingRepository.GetBookingByIdAsync(bookingId);
            var booking = _mapper.Map<BookingDto>(bookingFromDb);
            return PartialView("_ViewBookingModal", booking);
        }
    }
}
