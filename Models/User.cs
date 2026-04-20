using System.ComponentModel.DataAnnotations;

namespace BarbershopAPI.Models
{
    public class User
    {
        public int id_user { get; set; }

        [Required]
        public string nama { get; set; }

        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        public string password { get; set; }
    }
}