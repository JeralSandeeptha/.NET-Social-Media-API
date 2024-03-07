using System.ComponentModel.DataAnnotations;

namespace SocialMediaApiLastChance.Models
{
    public class Post
    {
        public int PostId { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Navigation property for access userId
        public int UserId { get; set; }

        //if we dont use constructor then date time will be 0001-01-01 00:00:00
        // if we want now date and time then should use constructor
        public Post()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}
