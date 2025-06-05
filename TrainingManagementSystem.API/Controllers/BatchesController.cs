using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingManagementSystem.API.Models;
using TrainingManagementSystem.API.Services;

namespace TrainingManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatchesController : ControllerBase
    {
        private readonly IBatchRepository _repo;

        public BatchesController(IBatchRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _repo.GetAll());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var batch = await _repo.GetById(id);
                if (batch == null) return NotFound();
                return Ok(batch);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Server error: {ex.Message}");
            }
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Batch batch)
        {
            var created = await _repo.Add(batch);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }


        [HttpPut("{id}")]
       public async Task<IActionResult> Update(int id, [FromBody] Batch batch)
         {
           if (id != batch.Id)
            return BadRequest("ID mismatch");

          try
    {
        // Nullify navigation properties to avoid EF Core tracking issues
        batch.Course = null;
        batch.Enrolments = null;

        var updated = await _repo.Update(batch);
        return Ok(updated);
    }
    catch (Exception ex)
    {
        return StatusCode(500, $"Server error: {ex.Message}");
    }
}



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _repo.Delete(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }

}
