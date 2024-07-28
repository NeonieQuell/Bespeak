using AutoMapper;
using Bespeak.Entity.Entities;
using Bespeak.Web.Models;

namespace Bespeak.Web.Profiles
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<BookingDtoForCreate, Reservation>();
            CreateMap<Reservation, BookingDto>();
            CreateMap<Reservation, BookingDtoForUpdate>();
        }
    }
}
