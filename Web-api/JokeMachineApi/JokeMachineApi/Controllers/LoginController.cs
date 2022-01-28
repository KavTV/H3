using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JokeMachineApi.Controllers
{
    /// <summary>
    /// THIS IS WHERE YOU CAN GET A JWT TOKEN.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;

        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] UserModel login)
        {
            LoginProvider loginProvider = new LoginProvider(_config);
            IActionResult response = Unauthorized();
            var user = loginProvider.AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = loginProvider.GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }

        
    }
}
