using SocialMediaApiLastChance.Db;
using SocialMediaApiLastChance.Dto.Request;
using SocialMediaApiLastChance.Dto.Response;
using SocialMediaApiLastChance.Exceptions;
using SocialMediaApiLastChance.IServices;
using SocialMediaApiLastChance.Models;
using SocialMediaApiLastChance.Utils;

namespace SocialMediaApiLastChance.Services
{
    public class AdminService : IAdminService
    {
        public readonly AppDbContext _appDbContext;

        public AdminService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void DeleteAdmin(int id)
        {
            Admin adminToDelete = _appDbContext.Admins.Find(id);
            if (adminToDelete == null)
            {
                throw new ResourceNotFoundException($"Admin id({id})  not found");
            }
            _appDbContext.Admins.Remove(adminToDelete);
            _appDbContext.SaveChanges();
        }

        public AdminResponseDto GetAdminById(int id)
        {
            Admin admin = _appDbContext.Admins.Find(id);
            var adminResponse = new AdminResponseDto();
            adminResponse.AdminId = admin.AdminId;
            adminResponse.Username = admin.Username;
            adminResponse.Password = admin.Password;
            adminResponse.CreatedAt = admin.CreatedAt;
            adminResponse.UpdatedAt = admin.UpdatedAt;
            return adminResponse;
        }

        public List<Admin> GetAllAdmins()
        {
            return _appDbContext.Admins.ToList();
        }

        public AdminResponseDto RegisterAdmin(AdminRequestDto adminRequestDto)
        {
            var admin = new Admin()
            {
                Username = adminRequestDto.Username,
                Password = adminRequestDto.Password,
            };
            Admin savedAdmin = _appDbContext.Admins.Add(admin).Entity;
            _appDbContext.SaveChanges();
            var adminResponseDto = new AdminResponseDto
            {
                AdminId = savedAdmin.AdminId,
                Username = savedAdmin.Username,
                Password = savedAdmin.Password,
                CreatedAt = savedAdmin.CreatedAt,
                UpdatedAt = savedAdmin.UpdatedAt,
            };
            return adminResponseDto;
        }

        public AdminResponseDto UpdateAdmin(int id, AdminRequestDto adminRequestDto)
        {
            Admin admin = _appDbContext.Admins.Find(id);
            if (admin == null)
            {
                throw new ResourceNotFoundException($"Admin id({id}) not found.");
            }
            admin.Username = adminRequestDto.Username;
            admin.Password = adminRequestDto.Password; 
            admin.UpdatedAt = DateTime.UtcNow;
            _appDbContext.SaveChanges();
            var adminResponseDto = new AdminResponseDto
            {
                AdminId = admin.AdminId,
                Username = admin.Username,
                Password = admin.Password,
                CreatedAt = admin.CreatedAt,
                UpdatedAt = DateTime.UtcNow,
            };
            return adminResponseDto;
        }
    }
}
