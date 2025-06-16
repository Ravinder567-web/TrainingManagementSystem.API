using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingManagementSystem.API.DTOs;
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
        public async Task<IActionResult> Create([FromBody] BatchDTO batchDto)
        {
            try
            {
                var newBatch = new Batch
                {
                    BatchName = batchDto.BatchName,
                    StartDate = batchDto.StartDate,
                    EndDate = batchDto.EndDate,
                    CourseId = batchDto.CourseId
                };

                var created = await _repo.Add(newBatch);

                return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Server error: {ex.Message}");
            }
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] BatchDTO batchDto)
        {
            if (id != batchDto.Id)
                return BadRequest("ID mismatch");

            try
            {
                var existingBatch = await _repo.GetById(id);
                if (existingBatch == null)
                    return NotFound();

                
                existingBatch.BatchName = batchDto.BatchName;
                existingBatch.StartDate = batchDto.StartDate;
                existingBatch.EndDate = batchDto.EndDate;
                existingBatch.CourseId = batchDto.CourseId;

                var updated = await _repo.Update(existingBatch);
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
