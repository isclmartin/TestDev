using DEV.Entities;
using DEV.Services.Implementations;
using DEV.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace DEV.Auth.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<LoginResponse>> Authenticate([FromBody] LoginRequest loginInfo)
        {
            try
            {
                IUsersManagementService usersManagementService = new UsersManagementService();
                var userValid = await usersManagementService.AuthenticateUser(loginInfo);
                if (!userValid.Authenticated)
                {
                    return Unauthorized("La información de acceso es incorrecta.");
                }

                return Ok(userValid);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error al procesar la solicitud");
            }
        }

        [HttpPost("auth")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<LoginResponse>> Login(string userName, string password)
        {
            try
            {
                var loginInfo = new LoginRequest
                {
                    UserName = userName,
                    Password = password
                };

                IUsersManagementService usersManagementService = new UsersManagementService();
                var userValid = await usersManagementService.AuthenticateUser(loginInfo);
                if (!userValid.Authenticated)
                {
                    return Unauthorized("La información de acceso es incorrecta.");
                }

                return Ok(userValid);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error al procesar la solicitud");
            }
        }
    }
}
