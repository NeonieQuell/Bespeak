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

        public RoomsController(
            IMapper mapper,
            IRoomTypeRepository roomTypeRepository)
        {
            _mapper = mapper;
            _roomTypeRepository = roomTypeRepository;
        }

        public async Task<ActionResult> Index()
        {
            var roomTypesFromDb = await _roomTypeRepository.GetRoomTypesAsync();

            // Convert to dto
            var roomTypes = _mapper.Map<List<RoomTypeDto>>(roomTypesFromDb);

            var viewModel = new RoomsViewModel()
            {
                RoomTypes = roomTypes
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> CreateRoomType(RoomTypeDtoForCreate roomType)
        {
            if (await _roomTypeRepository.IsRoomTypeExistsAsync(roomType.TypeName))
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
    }
}
