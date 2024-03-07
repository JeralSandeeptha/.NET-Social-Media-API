using SocialMediaApiLastChance.Models;
using System.ComponentModel.DataAnnotations;

namespace SocialMediaApiLastChance.Dto.Request
{
    public class CommentRequestDto
    {
        public string Review { get; set; }
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Navigation property for access userId
        public int UserId { get; set; }
        // Navigation property for access user
        public User user;
        // Navigation property for access postId
        public int PostId { get; set; }
    }
}
