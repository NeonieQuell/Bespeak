﻿using AutoMapper;
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
        private readonly IBookingRepository _bookingRepository;

        #region Constructor
        public RoomsController(
            IMapper mapper,
            IRoomTypeRepository roomTypeRepository,
            IRoomRepository roomRepository,
            IBookingRepository bookingRepository)
        {
            _mapper = mapper;
            _roomTypeRepository = roomTypeRepository;
            _roomRepository = roomRepository;
            _bookingRepository = bookingRepository;
        }
        #endregion

        public async Task<ActionResult> Index()
        {
            var roomTypesFromDb = await _roomTypeRepository.GetRoomTypesAsync();
            var roomTypes = _mapper.Map<List<RoomTypeDto>>(roomTypesFromDb);

            // Get metadata for dto
            foreach (var rt in roomTypes)
            {
                rt.TotalRoomsOfType =
                    await _roomRepository.GetRoomsCountByRoomTypeAsync(rt.TypeName);

                rt.TotalBookedOfType =
                    await _bookingRepository.GetBookingsCountByRoomTypeAsync(rt.TypeName);
            }

            var roomsFromDb = await _roomRepository.GetRoomsAsync();
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
    }
}
