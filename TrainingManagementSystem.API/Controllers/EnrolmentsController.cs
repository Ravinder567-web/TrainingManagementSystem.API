using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingManagementSystem.API.Repositories;

namespace TrainingManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrolmentsController : ControllerBase
    {
        private readonly IEnrolmentRepository _repo;

        public EnrolmentsController(IEnrolmentRepository repo)
        {
            _repo = repo;
        }

        // For all roles
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var enrolment = await _repo.GetById(id);
            if (enrolment == null) return NotFound();
            return Ok(enrolment);
        }

        // EMPLOYEE: Request enrolment
        [Authorize(Roles = "Employee")]
        [HttpPost("request")]
        public async Task<IActionResult> RequestEnrolment([FromQuery] int userId, [FromQuery] int batchId)
        {
            var result = await _repo.RequestEnrolment(userId, batchId);
            return Ok(result);
        }

        // MANAGER: Approve or Reject
        [Authorize(Roles = "Manager")]
        [HttpPut("review/{id}")]
        public async Task<IActionResult> ReviewEnrolment(int id, [FromQuery] string status)
        {
            var result = await _repo.ApproveOrReject(id, status);
            if (result == null) return NotFound();
            return Ok(result);
        }

        // ADMIN/MANAGER: View all enrolments
        [Authorize(Roles = "Manager,Administrator")]
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _repo.GetAll());

        // EMPLOYEE: View own enrolments
        [Authorize(Roles = "Employee")]
        [HttpGet("employee/{userId}")]
        public async Task<IActionResult> GetByEmployee(int userId)
        {
            return Ok(await _repo.GetByUser(userId));
        }
    }

}
