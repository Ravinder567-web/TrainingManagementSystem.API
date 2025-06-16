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
            
            if (login.Username == "admin" && login.Password == "2355377")
            {
                var user = new User { Username = "Ravinder Amrudi", Role = "Trainer" };
                var token = _authService.GenerateToken(user);
                return Ok(new { Token = token });
            }

            return Unauthorized();
        }


    }

}
