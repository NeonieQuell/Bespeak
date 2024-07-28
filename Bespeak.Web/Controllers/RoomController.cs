using AutoMapper;
using Bespeak.DataAccess.Repositories.Base;
using Bespeak.Entity.Entities;
using Bespeak.Web.Models;
using Bespeak.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bespeak.Web.Controllers
{
    public class RoomController : Controller
    {
        private readonly IMapper mapper;
        private readonly IRoomTypeRepository roomTypeRepository;
        private readonly IRoomRepository roomRepository;
        private readonly IReservationRepository reservationRepository;

        public RoomController(IMapper mapper, IRoomTypeRepository roomTypeRepository, IRoomRepository roomRepository,
            IReservationRepository reservationRepository)
        {
            this.mapper = mapper;
            this.roomTypeRepository = roomTypeRepository;
            this.roomRepository = roomRepository;
            this.reservationRepository = reservationRepository;
        }

        public async Task<ActionResult> Index()
        {
            var roomTypesFromDb = await this.roomTypeRepository.GetListAsync(false);
            var roomTypes = this.mapper.Map<List<RoomTypeDto>>(roomTypesFromDb);

            // Get metadata for dto
            foreach (var rt in roomTypes)
            {
                rt.TotalRoomsOfType =
                    await this.roomRepository.GetRoomCountByRoomTypeAsync(rt.RoomTypeId);

                rt.TotalReservedOfType =
                    await this.reservationRepository.GetReservationsCountByRoomTypeAsync(rt.RoomTypeId);
            }

            var roomsFromDb = await this.roomRepository.GetListAsync(true, false);
            var rooms = this.mapper.Map<List<RoomDto>>(roomsFromDb);

            return View(new RoomViewModel()
            {
                RoomTypes = roomTypes,
                Rooms = rooms
            });
        }

        [HttpPost]
        public async Task<ActionResult> CreateRoomType(RoomTypeDtoForCreate roomTypeDtoForCreate)
        {
            if (await this.roomTypeRepository.IsRoomTypeExistsAsync(roomTypeDtoForCreate.Name.Trim()))
            {
                return Json(new
                {
                    result = false,
                    text = "This type already exists"
                });
            }

            await this.roomTypeRepository.AddAsync(this.mapper.Map<RoomType>(roomTypeDtoForCreate));

            return Json(new
            {
                result = true,
                text = "Type saved"
            });
        }

        [HttpPost]
        public async Task<ActionResult> CreateRoom(RoomDtoForCreate roomDtoForCreate)
        {
            await this.roomRepository.AddAsync(this.mapper.Map<Room>(roomDtoForCreate));

            return Json(new
            {
                text = "Room saved"
            });
        }

        [HttpGet]
        public async Task<ActionResult> EditRoom(Guid roomId)
        {
            // Get room object
            var roomFromDb = await this.roomRepository.GetByIdAsync(roomId, true, false);
            var room = this.mapper.Map<RoomDto>(roomFromDb);

            // Get room type list
            var roomTypesFromDb = await this.roomTypeRepository.GetListAsync(false);
            var roomTypes = this.mapper.Map<List<RoomTypeDto>>(roomTypesFromDb);

            return PartialView("~/Views/Rooms/EditRoomModal.cshtml", new EditRoomViewModel()
            {
                Room = room,
                RoomTypes = roomTypes
            });
        }
    }
}
