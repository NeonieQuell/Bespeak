using AutoMapper;
using Bespeak.DataAccess.Repositories.Base;
using Bespeak.Web.Models;
using Bespeak.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bespeak.Web.Controllers
{
    public class BookingsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRoomRepository _roomRepository;

        #region Constructor
        public BookingsController(
            IMapper mapper,
            IRoomRepository roomRepository)
        {
            _mapper = mapper;
            _roomRepository = roomRepository;
        }
        #endregion

        public async Task<ActionResult> Index()
        {
            var roomsFromDb = await _roomRepository.GetRoomsAsync();
            var rooms = _mapper.Map<List<RoomDto>>(roomsFromDb);

            var viewModel = new BookingsViewModel()
            {
                Rooms = rooms
            };

            return View(viewModel);
        }
    }
}
