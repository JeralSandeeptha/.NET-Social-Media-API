using SocialMediaApiLastChance.Models;
using System.ComponentModel.DataAnnotations;

namespace SocialMediaApiLastChance.Dto.Response
{
    public class CommentResponseDto
    {
        public int CommentId { get; set; }
        public string Review { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public int UserId { get; set; }
        public int PostId { get; set; }
    }
}
