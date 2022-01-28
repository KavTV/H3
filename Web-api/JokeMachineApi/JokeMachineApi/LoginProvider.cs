using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace JokeMachineApi
{
    public class LoginProvider
    {
        private IConfiguration _config;
        public LoginProvider(IConfiguration config)
        {
            _config = config;
        }
        public string GenerateJSONWebToken(UserModel userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //Make the token with credentials and settings taken from the appsettings.json
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              //TIME THE TOKEN IS ALIVE
              expires: DateTime.Now.AddMinutes(100),
              signingCredentials: credentials);
            //Return the token to user
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public UserModel AuthenticateUser(UserModel login)
        {
            UserDal userDal = new UserDal();
            //Validate the User Credentials
            UserModel user = userDal.GetUser(login.Username, login.Password);

            return user;
        }

    }
}
