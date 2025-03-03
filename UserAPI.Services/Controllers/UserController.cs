using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UserAPI.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IActionResult RecoverPassword()
        {
            return StatusCode(200);
        }
        public IActionResult CreateAccount()
        {
            return StatusCode(200);
        }
        public IActionResult Authentication()
        {
            return StatusCode(200);
        }
    }
}
