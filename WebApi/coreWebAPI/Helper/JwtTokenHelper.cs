using Data.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace coreWebAPI.Helper
{
    public class JwtTokenHelper
    {
        private string JwtKey = "RfUjXn2r5u8x/A?D(G-KPdSgVkYp3s6v";
        private string validIssuer = "http://cloud.apihealthcare.com/workforce";
        private string audiance = "https://localhost:7038";


        public JwtTokenHelper()
        {

        }

        public string CreateJwtToken(Users user, IEnumerable<string> roles)
        {
            // Create claims
            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Email, user.EmailId));

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                validIssuer,
                audiance,
                claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
