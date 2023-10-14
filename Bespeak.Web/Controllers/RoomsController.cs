using AutoMapper;
using Bespeak.DataAccess.Repositories.Base;
using Bespeak.Entity.Entities;
using Bespeak.Web.Models;
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

        public ActionResult Index()
        {
            return View();
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
