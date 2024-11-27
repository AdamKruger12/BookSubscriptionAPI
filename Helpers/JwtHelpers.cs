using BookSubscriptionApi.Interfaces;
using BookSubscriptionApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookSubscriptionApi.Helpers
{
    /// <summary>
    /// JwtHelpers class for authtoken generation
    /// </summary>
    public class JwtHelpers : IJwtHelper
    {
        private readonly string _secret = "SneakySecret"; //TODO: use env file or something here
        /// <summary>
        /// Generates a JWT token for a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public string GenerateToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: "bookingService",
                audience: "bookingService",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
