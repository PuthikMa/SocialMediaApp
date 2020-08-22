using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SocialMedia.API.Domain.Identity;
using SocialMedia.API.Infrastructure.Security.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.API.Infrastructure.Security
{
    public class JWTGenerator : IJWTGenerator
    {
        private readonly SymmetricSecurityKey key;
        private readonly UserManager<AppUser> userManager;

        public JWTGenerator(IConfiguration config, UserManager<AppUser> userManager)
        {
            var i = config.GetConnectionString("Key");
            key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.GetConnectionString("Key")));
            this.userManager = userManager;
        }
        public async Task<string> CreateToken(AppUser user)
        {
            var role = await userManager.GetRolesAsync(user);
            IdentityOptions option = new IdentityOptions();
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.UserName),
                new Claim(option.ClaimsIdentity.RoleClaimType,role.FirstOrDefault())
            };


            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDecriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDecriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
