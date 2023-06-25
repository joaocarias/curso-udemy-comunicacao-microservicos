using jcf.auth_api.app.Models;
using jcf.auth_api.app.Repositories;
using jcf.auth_api.app.Services;
using Microsoft.AspNetCore.Mvc;

namespace jcf.auth_api.app.Controllers
{
    [ApiController]
    [Route("v1")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> AuthenticateAsync([FromBody] User model)
        {
            var user = UserRepository.Get(model.UserName, model.Password);

            if (user == null)
            {
                return NotFound(new { message = "Usuário ou senha inválidos!" });
            }

            var token = TokenService.GenerateToken(user);
            user.Password = "";
            return Ok(new
            {
                user,
                token,
            });
        }
    }
}
