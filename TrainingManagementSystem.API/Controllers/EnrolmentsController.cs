using Microsoft.AspNetCore.Mvc;
using TrainingManagementSystem.API.Models;
using TrainingManagementSystem.API.Repositories;

namespace TrainingManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrolmentsController : ControllerBase
    {
        private readonly IEnrolmentRepository _repo;

        public EnrolmentsController(IEnrolmentRepository repo)
        {
            _repo = repo;
        }

      
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var enrolments = await _repo.GetAll();
            return Ok(enrolments);
        }

      
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var enrolment = await _repo.GetById(id);
            if (enrolment == null)
                return NotFound();

            return Ok(enrolment);
        }

      
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Enrolment enrolment)
        {
            var created = await _repo.Create(enrolment);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Enrolment enrolment)
        {
            if (id != enrolment.Id)
                return BadRequest();

            var updated = await _repo.Update(enrolment);
            if (updated == null)
                return NotFound();

            return Ok(updated);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _repo.Delete(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
