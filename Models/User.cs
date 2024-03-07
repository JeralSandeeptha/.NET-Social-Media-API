using System.ComponentModel.DataAnnotations;

namespace SocialMediaApiLastChance.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Navigation property for access posts
        public List<Post> Posts { get; set; }

        // Navigation property for access posts
        public List<Comment> Comments { get; set; }

        //if we dont use constructor then date time will be 0001-01-01 00:00:00
        // if we want now date and time then should use constructor
        public User()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            Posts = new List<Post>();
            Comments = new List<Comment>();
        }
    }
}
