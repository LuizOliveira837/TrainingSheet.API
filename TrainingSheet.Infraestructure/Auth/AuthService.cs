using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Unicode;
using System.Threading.Tasks;
using TrainingSheet.Core.Auth;

namespace TrainingSheet.Infraestructure.Auth
{
    public class AuthService : IAuthService
    {
        public readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string EncryptPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[]hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder stringBuilder = new StringBuilder();

                for(var i = 0; i < hashBytes.Length; i++)
                {
                    stringBuilder.Append(hashBytes[i].ToString("x2"));
                }

                return stringBuilder.ToString();
            }
        }

        public string GenerationToken(string email)
        {
            var claims = new Claim[]
            {
                new Claim("Email", email)
            };

            var issuer = _configuration["TokenConfigurations:Issuer"];
            var audience = _configuration["TokenConfigurations:Audience"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["TokenConfigurations:Secret-JWTKey"]));

            var signature = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(issuer: issuer, audience: audience, signingCredentials: signature);

            return new JwtSecurityTokenHandler().WriteToken(token); 
        }
    }
}
