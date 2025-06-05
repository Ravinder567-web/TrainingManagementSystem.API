using Microsoft.EntityFrameworkCore;
using TrainingManagementSystem.API.Data;
using TrainingManagementSystem.API.Models;
using TrainingManagementSystem.API.Repositories;

namespace TrainingManagementSystem.API.Services
{
    public class EnrolmentRepository : IEnrolmentRepository
    {
        private readonly ApplicationDbContext _context;

        public EnrolmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Enrolment>> GetAll()
            => await _context.Enrolments
                    .Include(e => e.User)
                    .Include(e => e.Batch)
                    .ThenInclude(b => b.Course)
                    .ToListAsync();

        public async Task<Enrolment> GetById(int id)
            => await _context.Enrolments
                    .Include(e => e.User)
                    .Include(e => e.Batch)
                    .FirstOrDefaultAsync(e => e.Id == id);

        public async Task<IEnumerable<Enrolment>> GetByUser(int userId)
            => await _context.Enrolments
                    .Include(e => e.Batch)
                    .ThenInclude(b => b.Course)
                    .Where(e => e.UserId == userId)
                    .ToListAsync();

        public async Task<IEnumerable<Enrolment>> GetByManager(int managerId)
        {
            // Optional: Add logic to filter enrolments based on manager's departments or team
            return await _context.Enrolments
                .Include(e => e.User)
                .Include(e => e.Batch)
                .ThenInclude(b => b.Course)
                .ToListAsync();
        }

        public async Task<Enrolment> RequestEnrolment(int userId, int batchId)
        {
            var enrolment = new Enrolment
            {
                UserId = userId,
                BatchId = batchId,
                Status = "Requested"
            };

            _context.Enrolments.Add(enrolment);
            await _context.SaveChangesAsync();
            return enrolment;
        }

        public async Task<Enrolment> ApproveOrReject(int id, string status)
        {
            var enrolment = await _context.Enrolments.FindAsync(id);
            if (enrolment == null) return null;

            enrolment.Status = status;
            await _context.SaveChangesAsync();
            return enrolment;
        }
    }

}
