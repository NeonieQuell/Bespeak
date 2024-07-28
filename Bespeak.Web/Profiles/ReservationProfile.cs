using AutoMapper;
using Bespeak.Entity.Entities;
using Bespeak.Web.Models;

namespace Bespeak.Web.Profiles
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile()
        {
            CreateMap<ReservationDtoForCreate, Reservation>();
            CreateMap<Reservation, ReservationDto>();
        }
    }
}
