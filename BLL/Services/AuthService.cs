using BLL.Interfaces;
using DAL.DataAccess;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly ToDoContext _context;
        private readonly IConfiguration _configuration;
        public AuthService(ToDoContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<string> AuthenticateAsync(string username, string password)
        {
            var user = await _context.users.FirstOrDefaultAsync(u => u.username == username);
            if (user == null || user.password != password)
            {
                return "Invalid credential";
            }
            return GenerateToken(user);
        }

        public string GenerateToken(User user)
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.user_id.ToString()),
                new Claim(ClaimTypes.Name, user.username),
                new Claim(ClaimTypes.Email, user.email),
                new Claim(ClaimTypes.Role, user.role)
            };

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
