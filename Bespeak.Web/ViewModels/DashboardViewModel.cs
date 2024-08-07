﻿using Bespeak.Web.Models;

namespace Bespeak.Web.ViewModels
{
    public class DashboardViewModel
    {
        public int TotalRooms { get; set; }

        public int AvailableRooms { get; set; }

        public int OccupiedRooms { get; set; }

        public List<ReservationDto> Reservations { get; set; }

        public DashboardViewModel()
        {
            Reservations = new List<ReservationDto>();
        }
    }
}
