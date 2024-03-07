using SocialMediaApiLastChance.Dto.Request;
using SocialMediaApiLastChance.Dto.Response;
using SocialMediaApiLastChance.Models;

namespace SocialMediaApiLastChance.IServices
{
    public interface IUserService
    {
        List<User> GetAllUsers();
        UserResponseDto GetUser(int id);
        UserResponseDto UpdateUser(int id, UserRequestDto userRequestDto);
        UserResponseDto RegisterUser(UserRequestDto userRequestDto);
        void DeleteUser(int id);
    }
}
