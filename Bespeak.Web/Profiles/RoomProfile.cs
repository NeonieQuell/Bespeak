using AutoMapper;
using Bespeak.Entity.Entities;
using Bespeak.Web.Models;

namespace Bespeak.Web.Profiles
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<RoomDtoForCreate, Room>();
            CreateMap<Room, RoomDto>();
        }
    }
}
