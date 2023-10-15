using AutoMapper;
using Bespeak.Entity.Entities;
using Bespeak.Web.Models;

namespace Bespeak.Web.Profiles
{
    public class RoomTypeProfile : Profile
    {
        public RoomTypeProfile()
        {
            // Dto for create to entity
            CreateMap<RoomTypeDtoForCreate, RoomType>();
            CreateMap<RoomDtoForCreate, Room>();

            // Entity to base dto
            CreateMap<RoomType, RoomTypeDto>();
            CreateMap<Room, RoomDto>();
        }
    }
}
