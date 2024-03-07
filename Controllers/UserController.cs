using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMediaApiLastChance.Dto.Request;
using SocialMediaApiLastChance.Exceptions;
using SocialMediaApiLastChance.IServices;
using SocialMediaApiLastChance.Services;
using SocialMediaApiLastChance.Utils;

namespace SocialMediaApiLastChance.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;    
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            try
            {
                var users = _userService.GetAllUsers();
                return Ok(new SuccessResponse(
                            200,
                            "Get all users query was successful",
                            users
                        )
                    );
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse(
                        500,
                        "Get all users Internal Server Error",
                        ex
                    )
                );
            }
        }

        [HttpGet("{userId}")]
        public IActionResult GetUser(int userId)
        {
            try
            {
                var user = _userService.GetUser(userId);
                if (user == null)
                {
                    throw new ResourceNotFoundException($"User id({userId})  not found");
                }
                return Ok(
                        new SuccessResponse(
                            200,
                            "Get user query was successful",
                            user
                        )
                    );
            }
            catch (Exception ex)
            {
                var response = new
                {
                    StatusCode = 500,
                    Message = "Get user query Internal Server Error",
                    Error = ex,
                };

                return StatusCode(500, response);
            }
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] UserRequestDto userRequestDto)
        {
            try
            {
                var user = _userService.RegisterUser(userRequestDto);
                return Ok(
                        new SuccessResponse(
                            201,
                            "Create user query was successful",
                            user
                        )
                    );
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse(
                        500,
                        "Create user Internal Server Error",
                        ex
                    )
                );
            }
        }

        [HttpPut("{userId}")]
        public IActionResult UdateUser(int userId, [FromBody] UserRequestDto userRequestDto)
        {
            try
            {
                var user = _userService.UpdateUser(userId, userRequestDto);
                return Ok(
                        new SuccessResponse(
                            201,
                            "Update user query was successful",
                            user
                        )
                    );
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse(
                        500,
                        "Update user Internal Server Error",
                        ex
                    )
                );
            }
        }

        [HttpDelete("{userId}")]
        public IActionResult DeleteUser(int userId)
        {
            try
            {
                _userService.DeleteUser(userId);
                return Ok(
                        new SuccessResponse(
                            200,
                            "Delete user query was successful",
                            $"User({userId}) deleted"
                        )
                    );
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse(
                        500,
                        "Delete user Internal Server Error",
                        ex
                    )
                );
            }
        }
    }
}
