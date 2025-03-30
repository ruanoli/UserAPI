using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using UserAPI.Application.Interfaces;
using UserAPI.Application.Models;
using UserAPI.Domain.Exceptions;
using UserAPI.Domain.Interfaces.Repositories;
using UserAPI.Domain.Interfaces.Services;
using UserAPI.Services.Configurations;
using UserAPI.Services.Security;
using UserAPI.Services.Settings;

namespace UserAPI.Services.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IOptions<JwtSettings> _jwtSettings;
        private readonly TokenSecurity _tokenSecurity;
        private readonly IUserAppService _userAppService;

        public UserController(IOptions<JwtSettings> jwtSettings, TokenSecurity tokenSecurity, IUserAppService userAppService)
        {
            _jwtSettings = jwtSettings;
            _tokenSecurity = tokenSecurity;
            _userAppService = userAppService;
        }



        [Route("createAccount")]
        [HttpPost]
        [ProducesResponseType(typeof(CreateAccountResponseModel), 201)]
        public IActionResult CreateAccount(CreateAccountRequestModel model)
        {
            try
            {
                var response = _userAppService.CreateAccount(model);

                return StatusCode(200, response);
            }
            catch (UserAlreadyRegistredException ex)
            {
                return StatusCode(400, new { message = ex.Message });
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { message = ex.Message });
            }


        }

        [Route("userAuthentication")]
        [HttpPost]
        [ProducesResponseType(typeof(AuthenticateResponseModel), 200)]
        public IActionResult Authentication(AuthenticateRequestModel model)
        {
            try
            {
                var response = _userAppService.Authenticate(model);
                response.AccessToken = _tokenSecurity.CreateToken(model.Email);
                response.DateTimeExpiration = DateTime.Now.AddHours(_jwtSettings.Value.ExpirationInHours);

                return StatusCode(200, response);

            }
            catch (UnauthorizedAccessException ex)
            {
                return StatusCode(401, new { message = ex.Message });
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }

        }

        [Route("recoverPassword")]
        [HttpPost]
        [ProducesResponseType(typeof(RecoverPasswordResponseModel), 200)]
        public IActionResult RecoverPassword(RecoverPasswordRequestModel model)
        {
            try
            {
                var response = _userAppService.RecoverPassword(model);

                return StatusCode(200, response);

            }
            catch (UserNotFoundException ex)
            {
                return StatusCode(404, new { message = ex.Message });
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }

        }

        [Authorize]
        [Route("updateData")]
        [HttpPut]
        public IActionResult UpdateData()
        {
            return StatusCode(200);
        }

    }
}
