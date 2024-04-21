using Dtos;
using Dtos.Returns;
using Helpers.Errors;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BackEndProject.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController(IUserService userService) : ControllerBase
    {
        [HttpPost, Route("")]
        [SwaggerOperation(
            Summary = "Create a new user in User table.",
            OperationId = "SaveAnUser",
            Tags = ["User"]
        )]
        public async Task<IActionResult> SaveAnNewUser([FromBody] UserDto userDto)
        {
            try
            {
                await userService.SaveAnNewUser(userDto);
                
                return Created(string.Empty, new BasicReturnCreatedDto());
            }
            catch (Exception e)
            {
                return StatusCode(500, HelperError.GetErrorAndInnerError(e));
            }
        }
        
        [HttpPost, Route("loginUser")]
        [SwaggerOperation(
            Summary = "Get the user information with the email.",
            Description = "The email comes from the HttpContext.",
            OperationId = "GetUser",
            Tags = ["User"]
        )]
        public async Task<IActionResult> LoginUser([FromBody] UserLoginDto userLoginDto)
        {
            try
            {
                return Ok(await userService.GetUserInSession(userLoginDto));
            }
            catch (Exception e)
            {
                return StatusCode(500, HelperError.GetErrorAndInnerError(e));
            }
        }
    }
}

