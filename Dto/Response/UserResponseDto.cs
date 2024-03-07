using System.ComponentModel.DataAnnotations;

namespace SocialMediaApiLastChance.Dto.Response
{
    public class UserResponseDto
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
