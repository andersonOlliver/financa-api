using Financa.CrossCuting.Models;
using Financa.Domain.Entities;
using Financa.Domain.Interfaces.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Financa.Domain.Services
{
    public class JwtService : IJwtService
    {
        private readonly AppSettings _appSettings;

        public JwtService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public (string, DateTime) GenerateToken(Usuario usuario)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var expires = DateTime.UtcNow.AddDays(7);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim("id", usuario.Id.ToString()),
                    new Claim("displayName", usuario.Nome)
                }),
                Expires = expires,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return (tokenHandler.WriteToken(token), expires);
        }

        //public RefreshToken GenerateRefreshToken(string ipAddress)
        //{
        //    var randomNumber = new byte[32];
        //    using var generator = new RNGCryptoServiceProvider();
        //    generator.GetBytes(randomNumber);
        //    return new RefreshToken
        //    {
        //        RefreshTokenId = Guid.NewGuid(),
        //        Token = Convert.ToBase64String(randomNumber),
        //        Expires = DateTime.UtcNow.AddDays(10),
        //        Created = DateTime.UtcNow,
        //        CreatedByIp = ipAddress
        //    };
        //}

        public Guid? ValidateToken(string? token)
        {
            if (token is null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = Guid.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

                // return user id from JWT token if validation successful
                return userId;
            }
            catch
            {
                // return null if validation fails
                return null;
            }
        }

        //public string RandomTokenString() => RandomString();

        //// Generates a random password.  
        //// 4-LowerCase + 4-Digits + 2-UpperCase  
        //private string RandomString()
        //{
        //    var generator = new RandomGenerator();
        //    var passwordBuilder = new StringBuilder();

        //    // 4-Letters lower case   
        //    passwordBuilder.Append(generator.RandomString(6, true));

        //    // 4-Digits between 1000 and 9999  
        //    passwordBuilder.Append(generator.RandomNumber(100000, 999999));

        //    // 2-Letters upper case  
        //    passwordBuilder.Append(generator.RandomString(4));
        //    return passwordBuilder.ToString();
        //}
    }
}
