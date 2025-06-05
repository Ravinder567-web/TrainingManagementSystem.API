using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrainingManagementSystem.API.AuthService;
using TrainingManagementSystem.API.DTOs;
using TrainingManagementSystem.API.Models;
using TrainingManagementSystem.API.Repository_Interface;

namespace TrainingManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtTokenService _authService;
       

        public AuthController(JwtTokenService authService)
        {
            _authService = authService;
            
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO login)
        {
            // Replace with real DB validation
            if (login.Username == "admin" && login.Password == "2355377")
            {
                var user = new User { Username = "admin", Role = "Administrator" };
                var token = _authService.GenerateToken(user);
                return Ok(new { Token = token });
            }

            return Unauthorized();
        }

      /*  [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            var user = await _userRepo.GetByUsername(login.Username);
            if (user == null || user.PasswordHash != login.Password) // use hashed passwords in production
                return Unauthorized();

            var token = _authService.GenerateToken(user);
            return Ok(new { Token = token, Role = user.Role });
        }*/

        // [Authorize(Roles = "Administrator")]
        // [HttpGet("admin/dashboard")]
        // public IActionResult AdminDashboard() => Ok("Welcome Admin!");


    }

}
