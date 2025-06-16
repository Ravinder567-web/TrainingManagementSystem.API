using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainingManagementSystem.API.Models;
using TrainingManagementSystem.API.Repository_Interface;

namespace TrainingManagementSystem.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
   
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repo;

        public UsersController(IUserRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _repo.GetAll());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _repo.GetById(id);
            if (user == null) return NotFound();
            return Ok(user);
        }
       
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            try
            {
                var created = await _repo.Add(user);
                return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, new { message = "Internal Server Error", detail = ex.Message });
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] User user)
        {
            if (id != user.Id) return BadRequest();
            return Ok(await _repo.Update(user));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _repo.Delete(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }

}
