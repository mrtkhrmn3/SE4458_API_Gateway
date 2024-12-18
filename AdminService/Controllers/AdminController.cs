using AdminService.Context;
using AdminService.DTO;
using AdminService.Model;
using AdminService.Token;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdminService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly AdminDbContext _context;
        private readonly IConfiguration _configuration;

        public AdminController(AdminDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;

        }

        [HttpPost("Register")]
        public IActionResult Register(RegisterDTO dto)
        {
            var admin = new Admin
            {
                Username = dto.Username,
                Password = dto.Password
            };
            if(_context.Admins.Any(a => a.Username == dto.Username))
            {
                return BadRequest("Username already exists.");
            }
            _context.Admins.Add(admin);
            _context.SaveChanges();
            return Ok("Admin registered successfully.");
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginDTO dto)
        {
            var admin = new Admin
            {
                Username = dto.Username,
                Password = dto.Password
            };

            var existingAdmin = _context.Admins.FirstOrDefault(a => a.Username == dto.Username && a.Password == dto.Password);

            if (existingAdmin == null)
            {
                return Unauthorized("Invalid username or password.");
            }

            var token = TokenHandler.CreateToken(_configuration);
            return Ok(new { Token = token.AccessToken, Expiration = token.Expiration });
            
        }
    }
}
