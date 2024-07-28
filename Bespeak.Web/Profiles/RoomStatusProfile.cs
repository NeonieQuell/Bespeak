using AutoMapper;
using Bespeak.Entity.Entities;
using Bespeak.Web.Models;

namespace Bespeak.Web.Profiles
{
    public class RoomStatusProfile : Profile
    {
        public RoomStatusProfile()
        {
            CreateMap<RoomStatus, RoomStatusDto>();
        }
    }
}
