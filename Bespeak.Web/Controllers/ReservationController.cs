using AutoMapper;
using Bespeak.DataAccess.Repositories.Base;
using Bespeak.Entity.Entities;
using Bespeak.Web.Models;
using Bespeak.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bespeak.Web.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IMapper mapper;
        private readonly IRoomRepository roomRepository;
        private readonly IReservationRepository reservationRepository;

        public ReservationController(IMapper mapper, IRoomRepository roomRepository, IReservationRepository reservationRepository)
        {
            this.mapper = mapper;
            this.roomRepository = roomRepository;
            this.reservationRepository = reservationRepository;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var roomsFromDb = await this.roomRepository.GetListAsync(false, false);
            var rooms = this.mapper.Map<List<RoomDto>>(roomsFromDb);

            var reservationsFromDb = await this.reservationRepository.GetListAsync(false, false);
            var bookings = this.mapper.Map<List<ReservationDto>>(reservationsFromDb);

            return View(new ReservationViewModel()
            {
                Rooms = rooms,
                Reservations = bookings
            });
        }

        [HttpPost]
        public async Task<ActionResult> Reserve(ReservationDtoForCreate reservationDtoForCreate)
        {
            var reservationToSave = this.mapper.Map<Reservation>(reservationDtoForCreate);

            // Default results
            bool result = false;
            string titleResult = "Reservation unsuccessful";
            string textResult = "Conflict on the room's date of reservation";

            if (await this.reservationRepository.IsAvailable(reservationToSave))
            {
                await this.reservationRepository.AddAsync(reservationToSave);
                result = true;
                titleResult = "Reserved successfully";
                textResult = $"Reservation Reference No.: {reservationToSave.ReservationId}";
            }

            return Json(new
            {
                result,
                title = titleResult,
                text = textResult
            });
        }

        [HttpGet]
        public async Task<ActionResult> GetReservation(int reservationId)
        {
            var reservationFromDb = await this.reservationRepository.GetByIdAsync(reservationId, false);
            var reservation = this.mapper.Map<ReservationDto>(reservationFromDb);
            return PartialView("_ViewReservationModal", reservation);
        }

        [HttpGet]
        public async Task<ActionResult> EditReservation(int reservationId)
        {
            var reservationFromDb = await this.reservationRepository.GetByIdAsync(reservationId, false);
            var reservation = this.mapper.Map<ReservationDtoForUpdate>(reservationFromDb);

            var roomsFromDb = await this.roomRepository.GetListAsync(true, false);
            var rooms = this.mapper.Map<List<RoomDto>>(roomsFromDb);

            return PartialView("_EditBookingModal", new EditReservationViewModel()
            {
                Reservation = reservation,
                Rooms = rooms
            });
        }

        [HttpPost]
        public async Task<ActionResult> UpdateReservation(ReservationDtoForUpdate reservation)
        {
            var reservationFromDb = await this.reservationRepository.GetByIdAsync(reservation.ReservationId);

            this.mapper.Map(reservation, reservationFromDb);

            await this.reservationRepository.UpdateAsync(reservationFromDb!);

            return Json(new
            {
                text = "Reservation was updated"
            });
        }
    }
}
