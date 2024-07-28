using AutoMapper;
using Bespeak.DataAccess.Repositories.Base;
using Bespeak.Entity.Entities;
using Bespeak.Web.Models;
using Bespeak.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bespeak.Web.Controllers
{
    public class RoomsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRoomTypeRepository _roomTypeRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IReservationRepository _bookingRepository;

        #region Constructor
        public RoomsController(
            IMapper mapper,
            IRoomTypeRepository roomTypeRepository,
            IRoomRepository roomRepository,
            IReservationRepository bookingRepository)
        {
            _mapper = mapper;
            _roomTypeRepository = roomTypeRepository;
            _roomRepository = roomRepository;
            _bookingRepository = bookingRepository;
        }
        #endregion

        public async Task<ActionResult> Index()
        {
            var roomTypesFromDb = await _roomTypeRepository.GetListAsync();
            var roomTypes = _mapper.Map<List<RoomTypeDto>>(roomTypesFromDb);

            // Get metadata for dto
            foreach (var rt in roomTypes)
            {
                rt.TotalRoomsOfType =
                    await _roomRepository.GetRoomCountByRoomTypeAsync(rt.TypeName);

                rt.TotalBookedOfType =
                    await _bookingRepository.GetReservationsCountByRoomTypeAsync(rt.TypeName);
            }

            var roomsFromDb = await _roomRepository.GetListAsync();
            var rooms = _mapper.Map<List<RoomDto>>(roomsFromDb);

            var viewModel = new RoomsViewModel()
            {
                RoomTypes = roomTypes,
                Rooms = rooms
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> CreateRoomType(RoomTypeDtoForCreate roomType)
        {
            if (await _roomTypeRepository.IsRoomTypeExistsAsync(roomType.TypeName.Trim()))
            {
                return Json(new
                {
                    result = false,
                    text = "Type already exists"
                });
            }

            await _roomTypeRepository.AddAsync(_mapper.Map<RoomType>(roomType));

            return Json(new
            {
                result = true,
                text = "Type saved successfully"
            });
        }

        [HttpPost]
        public async Task<ActionResult> CreateRoom(RoomDtoForCreate room)
        {
            await _roomRepository.AddAsync(_mapper.Map<Room>(room));

            return Json(new
            {
                text = "Room saved successfully"
            });
        }

        [HttpGet]
        public async Task<ActionResult> EditRoom(string roomId)
        {
            // Get room object
            var roomFromDb = await _roomRepository.GetByIdAsync(roomId, true, false);
            var room = _mapper.Map<RoomDto>(roomFromDb);

            // Get room type list
            var roomTypesFromDb = await _roomTypeRepository.GetListAsync();
            var roomTypes = _mapper.Map<List<RoomTypeDto>>(roomTypesFromDb);

            var viewModel = new EditRoomViewModel()
            {
                Room = room,
                RoomTypes = roomTypes
            };

            return PartialView("~/Views/Rooms/EditRoomModal.cshtml", viewModel);
        }
    }
}
