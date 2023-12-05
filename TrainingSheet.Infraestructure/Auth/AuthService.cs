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
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder stringBuilder = new StringBuilder();

                for (var i = 0; i < hashBytes.Length; i++)
                {
                    stringBuilder.Append(hashBytes[i].ToString("x2"));
                }

                return stringBuilder.ToString();
            }
        }

        public string GenerationToken(string email)
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            var issuer = Settings.ISSUER;
            var audience = Settings.AUDIENCE;
            var secretKey = Encoding.UTF8.GetBytes(Settings.SECRETKEY);
            var listClaims = new List<Claim>() {
                    new Claim(ClaimTypes.Email, email),
                    new Claim(ClaimTypes.Role, "Practitioner")
            };



            var descriptor = new SecurityTokenDescriptor
            {
                Issuer = issuer,
                Audience = audience,
                Subject = new ClaimsIdentity(listClaims),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256),
            };

            var securityToken = tokenHandler.CreateToken(descriptor);

            return tokenHandler.WriteToken(securityToken);

        }
    }
}
