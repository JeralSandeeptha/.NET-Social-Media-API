using System.ComponentModel.DataAnnotations;

namespace SocialMediaApiLastChance.Models
{
    public class Admin
    {
        public int AdminId { get; set; }
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        //if we dont use constructor then date time will be 0001-01-01 00:00:00
        // if we want now date and time then should use constructor
        public Admin()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}
