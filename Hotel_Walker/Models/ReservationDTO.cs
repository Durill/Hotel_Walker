using System.ComponentModel;

namespace Hotel_Walker.Models
{
    public class ReservationDTO
    {
        public int Id { get; set; }

        [DisplayName("Arrival Date")]
        public DateTime ArrivalDate { get; set; }

        [DisplayName("Departure Date")]
        public DateTime DepartureDate { get; set; }
    }
}
