using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using UserAPI.Domain.Interfaces.Repositories;
using UserAPI.Domain.Interfaces.Services;
using UserAPI.Services.Models;
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
        private readonly IUserDomainService _userDomainService;

        public UserController(IOptions<JwtSettings> jwtSettings, TokenSecurity tokenSecurity, IUserDomainService userDomainService)
        {
            _jwtSettings = jwtSettings;
            _tokenSecurity = tokenSecurity;
            _userDomainService = userDomainService;
        }



        [Route("createAccount")]
        [HttpPost]
        [ProducesResponseType(typeof(CreateAccountResponseModel), 201)]
        public IActionResult CreateAccount(CreateAccountRequestModel model)
        {
            try
            {
                var createAccount = new CreateAccountResponseModel()
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name,
                    AccessDate = DateTime.UtcNow,
                    DateTimeExpiration = DateTime.UtcNow,
                    Email = model.Email,
                    AccessToken = ""
                };

                return StatusCode(200);
            }
            catch (Exception)
            {

                return StatusCode(500);
            }


        }

        [Route("userAuthentication")]
        [HttpPost]
        [ProducesResponseType(typeof(AuthenticateResponseModel), 200)]
        public IActionResult Authentication(AuthenticateRequestModel model)
        {
            try
            {
                if("admintest@test.com".Equals(model.Email) && "@Admin12345".Equals(model.Password))
                {
                    var response = new AuthenticateResponseModel()
                    {
                        Id = Guid.NewGuid(),
                        DateTimeExpiration = DateTime.Now.AddHours(_jwtSettings.Value.ExpirationInHours),
                        Email = model.Email,
                        Name = "User ADM",
                        AccessDate = DateTime.Now,
                        AccessToken = _tokenSecurity.CreateToken(model.Email)
                    };
                        
                    return StatusCode(200, response);
                }
                else
                {
                    return StatusCode(401);
                }
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
            return StatusCode(200);
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
