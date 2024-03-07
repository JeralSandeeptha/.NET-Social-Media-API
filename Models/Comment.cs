using System.ComponentModel.DataAnnotations;

namespace SocialMediaApiLastChance.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        [Required(ErrorMessage = "Review is required")]
        public string Review { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Navigation property for access userId
        public int UserId { get; set; }
        // Navigation property for access user
        public User user;
        // Navigation property for access postId
        public int PostId { get; set; }

        //if we dont use constructor then date time will be 0001-01-01 00:00:00
        // if we want now date and time then should use constructor
        public Comment()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}
