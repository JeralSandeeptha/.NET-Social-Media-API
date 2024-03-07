using SocialMediaApiLastChance.Db;
using SocialMediaApiLastChance.Dto.Request;
using SocialMediaApiLastChance.Dto.Response;
using SocialMediaApiLastChance.Exceptions;
using SocialMediaApiLastChance.IServices;
using SocialMediaApiLastChance.Models;

namespace SocialMediaApiLastChance.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _appDbContext;
        public UserService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void DeleteUser(int id)
        {
            User user = _appDbContext.Users.Find(id);
            if (user == null)
            {
                throw new ResourceNotFoundException($"User ({id}) not found");
            }
            else
            {
                _appDbContext.Users.Remove(user);
                _appDbContext.SaveChanges();
            }
        }

        public List<User> GetAllUsers()
        {
            return _appDbContext.Users.ToList();
        }

        public UserResponseDto GetUser(int id)
        {
            User user = _appDbContext.Users.Find(id);
            if (user == null)
            {
                throw new ResourceNotFoundException($"User ({id}) not found");
            }
            else 
            {
                var userResponseDto = new UserResponseDto()
                {
                    UserId = user.UserId,
                    Username = user.Username,
                    Password = user.Password,
                    Address = user.Address,
                    CreatedAt = user.CreatedAt,
                    UpdatedAt = user.UpdatedAt,
                };
                return userResponseDto;
            }
        }

        public UserResponseDto RegisterUser(UserRequestDto userRequestDto)
        {
            var user = new User()
            {
                Username = userRequestDto.Username,
                Password = userRequestDto.Password,
                Address = userRequestDto.Address
            };
            _appDbContext.Users.Add(user);
            _appDbContext.SaveChanges();
            var savedUser = new UserResponseDto()
            {
                UserId = user.UserId,
                Username = user.Username,
                Password = user.Password,
                Address = user.Address,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt,
            };
            return savedUser;
        }

        public UserResponseDto UpdateUser(int id, UserRequestDto userRequestDto)
        {
            User user = _appDbContext.Users.Find(id);
            user.Username = userRequestDto.Username;
            user.Password = userRequestDto.Password;
            user.UpdatedAt = DateTime.UtcNow;
            if (user == null)
            {
                throw new ResourceNotFoundException($"User ({id}) not found");
            }
            else
            {
                _appDbContext.SaveChanges();
                var userResponseDto = new UserResponseDto()
                {
                    UserId = user.UserId,
                    Username = user.Username,
                    Password = user.Password,
                    Address = user.Address,
                    CreatedAt = user.CreatedAt,
                    UpdatedAt = user.UpdatedAt,
                };
                return userResponseDto;
            }
        }
    }
}
