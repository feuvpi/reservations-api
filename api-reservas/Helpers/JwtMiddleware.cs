using api_reservas.Core.Models.BaseModels;
using api_reservas.Core.Models.Config;
using api_reservas.Core.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace api_reservas.Helpers
{
    public class JwtMiddleware
    {

        private readonly JwtSettings _jwtSettings;

        public JwtMiddleware(IConfiguration configutarion)
        {
            _jwtSettings = configutarion.GetSection("Jwt").Get<JwtSettings>();
        }

        //public string GenerateToken(BaseUser user)
        //{
        //    var claims = new List<Claim>
        //    {
        //        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        //        new Claim(ClaimTypes.Name, user.Email.ToString()),

        //    };

        //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
        //    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(claims),
        //        Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.TokenExpireInMinutes),
        //        SigningCredentials = credentials,
        //        Issuer = _jwtSettings.Issuer,
        //        Audience = _jwtSettings.Audience,
        //    };

        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var securityToken = tokenHandler.CreateToken(tokenDescriptor);
        //    return tokenHandler.WriteToken(securityToken);

        //}



    }
}
