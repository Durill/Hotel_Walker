using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Hotel_Walker.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public string? UserId { get; set; }
        public virtual IdentityUser? User { get; set; }

        [Display(Name = "Arrival date")]
        public DateTime ArrivalDate { get; set; }

        [Display(Name = "Departure date")]
        public DateTime DepartureDate { get; set; }
        public int PaidDays { get; set; }
        public string Status { get; set; }
        public bool IsAccepted { get; set; }
        public bool IsCancelled { get; set; }
    }
}
