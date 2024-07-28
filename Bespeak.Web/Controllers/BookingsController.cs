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

        [HttpGet]
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
            var bookingToSave = _mapper.Map<Reservation>(booking);

            // Default results
            bool result = false;
            string titleResult = "Booking unsuccessful";
            string textResult = "Conflict on the room's date of booking";

            if (await _bookingRepository.IsAvailable(bookingToSave))
            {
                await _bookingRepository.AddAsync(bookingToSave);
                result = true;
                titleResult = "Booked successfully";
                textResult = $"Your booking ID is: {bookingToSave.ReservationId}";
            }

            return Json(new
            {
                result,
                title = titleResult,
                text = textResult
            });
        }

        [HttpGet]
        public async Task<ActionResult> GetBooking(string bookingId)
        {
            var bookingFromDb = await _bookingRepository.GetBookingByIdAsync(bookingId, false);
            var booking = _mapper.Map<BookingDto>(bookingFromDb);
            return PartialView("_ViewBookingModal", booking);
        }

        [HttpGet]
        public async Task<ActionResult> EditBooking(string bookingId)
        {
            // Get booking object
            var bookingFromDb = await _bookingRepository.GetBookingByIdAsync(bookingId, false);
            var booking = _mapper.Map<BookingDtoForUpdate>(bookingFromDb);

            // Get rooms list
            var roomsFromDb = await _roomRepository.GetRoomsAsync();
            var rooms = _mapper.Map<List<RoomDto>>(roomsFromDb);

            var viewModel = new EditBookingViewModel()
            {
                Booking = booking,
                Rooms = rooms
            };

            return PartialView("_EditBookingModal", viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateBooking(BookingDtoForUpdate booking)
        {
            var bookingFromDb = await _bookingRepository.GetBookingByIdAsync(booking.BookingId, true);

            _mapper.Map(booking, bookingFromDb);

            await _bookingRepository.UpdateAsync(bookingFromDb!);

            return Json(new
            {
                text = "Booking updated successfully"
            });
        }
    }
}
