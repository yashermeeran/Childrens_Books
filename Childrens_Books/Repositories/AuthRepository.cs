using KidsBooks.Data;
using KidsBooks.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BCrypt.Net;

namespace KidsBooks.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;

        public AuthRepository(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<User> RegisterAsync(User user, string password)
        {
            if (await _context.Users.AnyAsync(u => u.Email == user.Email))
            {
                throw new ArgumentException("Email already exists.");
            }

            if (await _context.Users.AnyAsync(u => u.Username == user.Username))
            {
                throw new ArgumentException("Username already exists.");
            }

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<string> GenerateJwtTokenAsync(User user)
{
    var claims = new[]
    {
        new Claim("sub", user.Id.ToString()), 
        new Claim("name", user.Username),
        new Claim("email", user.Email), 
        new Claim("admin", "true"), 
        new Claim("iat", DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString())
    };

    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

    var token = new JwtSecurityToken(
        issuer: _config["Jwt:Issuer"],
        audience: _config["Jwt:Audience"],
        claims: claims,
        expires: DateTime.UtcNow.AddHours(1),
        signingCredentials: creds
    );

    return await Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
}



        public async Task<User> AuthenticateAsync(string username, string password)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Username == username);

            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                return null;
            }

            return user;
        }

        public Task RegisterAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
