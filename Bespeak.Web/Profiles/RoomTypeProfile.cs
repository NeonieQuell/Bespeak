using AutoMapper;
using Bespeak.Entity.Entities;
using Bespeak.Web.Models;

namespace Bespeak.Web.Profiles
{
    public class RoomTypeProfile : Profile
    {
        public RoomTypeProfile()
        {
            CreateMap<RoomType, RoomTypeDto>();
            CreateMap<RoomTypeDtoForCreate, RoomType>();
            CreateMap<RoomType, RoomTypeDtoForUpdate>().ReverseMap();
        }
    }
}
