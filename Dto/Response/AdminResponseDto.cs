namespace SocialMediaApiLastChance.Dto.Response
{
    public class AdminResponseDto
    {
        public int AdminId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
