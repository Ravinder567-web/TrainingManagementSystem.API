using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingManagementSystem.API.DTOs;
using TrainingManagementSystem.API.Models;
using TrainingManagementSystem.API.Repositories;

namespace TrainingManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseRepository _repo;
        private readonly IMapper _mapper;

        public CoursesController(ICourseRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCourses() => Ok(await _repo.GetAll());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var course = await _repo.GetById(id);
            if (course == null) return NotFound();
            return Ok(course);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] CourseDTO courseDto)
        {
            try
            {
                var course = _mapper.Map<Course>(courseDto);
                var created = await _repo.Add(course);
                var result = _mapper.Map<CourseDTO>(created);

                return CreatedAtAction(nameof(GetCourseById), new { id = result.Id }, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Server error: {ex.Message}");
            }
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, [FromBody] CourseDTO courseDto)
        {
            if (id != courseDto.Id)
                return BadRequest("ID in URL and body must match.");

            var existingCourse = await _repo.GetById(id);
            if (existingCourse == null)
                return NotFound();

            
            existingCourse.Title = courseDto.Title;
            existingCourse.Description = courseDto.Description;

            await _repo.Update(existingCourse);

            return NoContent();
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var deleted = await _repo.Delete(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }

}
