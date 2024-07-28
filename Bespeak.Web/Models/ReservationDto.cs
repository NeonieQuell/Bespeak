using System.ComponentModel.DataAnnotations;

namespace Bespeak.Web.Models
{
    public class ReservationDto
    {
        public int ReservationId { get; set; }

        /// <summary>
        /// The RoomId of RoomDto Object
        /// </summary>
        public Guid RoomId { get; set; }

        /// <summary>
        /// The Room Object of RoomId Property
        /// </summary>
        public RoomDto? Room { get; set; }

        /// <summary>
        /// The person's name who reserved
        /// </summary>
        public string Reserver { get; set; } = string.Empty;

        public DateTime CreateDate { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsArchived { get; set; }

        public DateOnly CreateDateFormatted
        {
            get
            {
                return DateOnly.FromDateTime(CreateDate);
            }
        }

        public DateOnly StartDateFormatted
        {
            get
            {
                return DateOnly.FromDateTime(StartDate);
            }
        }

        public DateOnly EndDateFormatted
        {
            get
            {
                return DateOnly.FromDateTime(EndDate);
            }
        }

        public string Duration
        {
            get
            {
                if (StartDate.Equals(EndDate))
                {
                    return "1 day";
                }
                else
                {
                    var timeDifference = (int)EndDate.Subtract(StartDate).TotalDays + 1;
                    string suffix = timeDifference > 1 ? "days" : "day";
                    return $"{timeDifference} {suffix}";
                }
            }
        }
    }

    public class ReservationDtoForCreate
    {
        [Required]
        public Guid RoomId { get; set; }

        [Required]
        public string Reserver { get; set; } = string.Empty;

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
    }

    // Unused
    public class ReservationDtoForUpdate : ReservationDto
    {

    }
}