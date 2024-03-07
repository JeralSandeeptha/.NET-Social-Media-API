using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMediaApiLastChance.Dto.Request;
using SocialMediaApiLastChance.Exceptions;
using SocialMediaApiLastChance.IServices;
using SocialMediaApiLastChance.Utils;

namespace SocialMediaApiLastChance.Controllers
{
    [Route("api/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public IActionResult GetAllAdmins()
        {
            try
            {
                var admins = _adminService.GetAllAdmins();
                return Ok(new SuccessResponse(
                            200,
                            "Get all users query was successful",
                            admins
                        )
                    );
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse(
                        500,
                        "Get all admins Internal Server Error",
                        ex
                    )
                );
            }
        }

        [HttpGet("{adminId}")]
        public IActionResult GetAdmin(int adminId)
        {
            try
            {
                var admin = _adminService.GetAdminById(adminId);
                if (admin == null)
                {
                    throw new ResourceNotFoundException($"Admin id({adminId})  not found");
                }
                return Ok(
                        new SuccessResponse(
                            200,
                            "Get user query was successful",
                            admin
                        )
                    );
            }
            catch (Exception ex)
            {
                var response = new
                {
                    StatusCode = 500,
                    Message = "Get admin query Internal Server Error",
                    Error = ex,
                };

                return StatusCode(500, response);
            }
        }

        [HttpPost]
        public IActionResult CreateAdmin(AdminRequestDto adminRequestDto)
        {
            try
            {
                var admin = _adminService.RegisterAdmin(adminRequestDto);
                return Ok(
                        new SuccessResponse(
                            201,
                            "Create user query was successful",
                            admin
                        )
                    );
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse(
                        500,
                        "Create admin Internal Server Error",
                        ex
                    )
                );
            }
        }

        [HttpPut("{adminId}")]
        public IActionResult UdateAdmin(int adminId, [FromBody] AdminRequestDto adminRequestDto)
        {
            try
            {
                var admin = _adminService.UpdateAdmin(adminId, adminRequestDto);
                return Ok(
                        new SuccessResponse(
                            201,
                            "Update user query was successful",
                            admin
                        )
                    );
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse(
                        500,
                        "Update admin Internal Server Error",
                        ex
                    )
                );
            }
        }

        [HttpDelete("{adminId}")]
        public IActionResult deleteAdmin(int adminId)
        {
            try
            {
                _adminService.DeleteAdmin(adminId);
                return Ok(
                        new SuccessResponse(
                            200,
                            "Delete user query was successful",
                            $"User({adminId}) deleted"
                        )
                    );
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse(
                        500,
                        "Delete admin Internal Server Error",
                        ex
                    )
                );
            }
        }
    }
}
