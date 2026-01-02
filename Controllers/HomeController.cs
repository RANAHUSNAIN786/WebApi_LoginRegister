using Microsoft.AspNetCore.Mvc;
using Webapinew.Models;

namespace Webapinew.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly MyContext _context;

        public HomeController(MyContext context)
        {
            _context = context;
        }

        [HttpPost("signup")]
        public IActionResult Signup(Users user)
        {
            if (user == null)
            {
                return BadRequest("Invalid data");
            }

            var exists = _context.Users.Any(u => u.Email == user.Email);

            if (exists)
            {
                return Conflict("Email already exists");
            }

            _context.Users.Add(user);   // ✅ FIXED
            _context.SaveChanges();

            return Ok("User registered successfully");
        }

        [HttpPost("login")]
        public IActionResult Login(Users login)
        {
            if (login == null)
            {
                return BadRequest("Invalid data");
            }

            var user = _context.Users
                .FirstOrDefault(u => u.Email == login.Email && u.Password == login.Password);

            if (user == null)
            {
                return Unauthorized("Invalid email or password");
            }

            return Ok(new
            {
                message = "Login successful",
                userId = user.Id,
                name = user.Name,
                email = user.Email
            });
        }


    }
}
