using System.ComponentModel;

namespace Hotel_Walker.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string RoomName { get; set; }
        public int NumberOfBeds { get; set; }
        public int Price { get; set; }

        [DefaultValue(true)]
        public bool IsActive { get; set; }
    }
}
