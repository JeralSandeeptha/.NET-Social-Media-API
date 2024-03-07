using SocialMediaApiLastChance.Dto.Request;
using SocialMediaApiLastChance.Dto.Response;
using SocialMediaApiLastChance.Models;

namespace SocialMediaApiLastChance.IServices
{
    public interface IAdminService
    {
        List<Admin> GetAllAdmins();
        AdminResponseDto RegisterAdmin(AdminRequestDto adminRequestDto);
        AdminResponseDto GetAdminById(int id);
        AdminResponseDto UpdateAdmin(int id, AdminRequestDto adminRequestDto);
        void DeleteAdmin(int id);
    }
}
