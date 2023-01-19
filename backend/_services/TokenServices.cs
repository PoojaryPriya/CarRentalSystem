using System.Text;
using System.IdentityModel.Tokens.Jwt;
using backend.Entities;
using backend.interfaces;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace backend._services
{
    public class TokenServices : ITokenservices
    {
        private readonly SymmetricSecurityKey _key;
        public TokenServices(IConfiguration config)
        {
            _key=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
        }

        public string CreateToken(UserClass user)
        {
            var claims=new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.UserName)
            };
            var creds=new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor=new SecurityTokenDescriptor
            {
                Subject= new ClaimsIdentity(claims),
                Expires=DateTime.Now.AddDays(10),
                SigningCredentials=creds
            };

            var tokenHandler =new JwtSecurityTokenHandler();
            var token =tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}