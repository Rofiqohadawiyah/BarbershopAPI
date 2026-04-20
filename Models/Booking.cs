using System.ComponentModel.DataAnnotations;

namespace BarbershopAPI.Models
{
    public class Booking
    {
        [Required]
        public int user_id { get; set; }

        [Required]
        public int barber_id { get; set; }

        [Required]
        public DateTime tanggal { get; set; }

        [Required]
        public TimeSpan jam { get; set; }
    }
}