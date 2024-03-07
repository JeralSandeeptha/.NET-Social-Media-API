using System.ComponentModel.DataAnnotations;

namespace SocialMediaApiLastChance.Dto.Request
{
    public class UserRequestDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
    }
}
