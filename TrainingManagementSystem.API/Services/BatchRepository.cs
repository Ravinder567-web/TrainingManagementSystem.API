using Microsoft.EntityFrameworkCore;
using TrainingManagementSystem.API.Data;
using TrainingManagementSystem.API.Models;
using TrainingManagementSystem.API.Services;

namespace TrainingManagementSystem.API.Repositories
{
    public class BatchRepository : IBatchRepository
    {
        private readonly ApplicationDbContext _context;

        public BatchRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Batch>> GetAll()
        {
            return await _context.Batches.ToListAsync(); 
        }

        public async Task<Batch> GetById(int id)
        {
            return await _context.Batches
                .Include(b => b.Course)
                .Include(b => b.Enrolments)
                    .ThenInclude(e => e.User)
                .FirstOrDefaultAsync(b => b.Id == id);
        }


        public async Task<Batch> Add(Batch batch)
        {
            _context.Batches.Add(batch);
            await _context.SaveChangesAsync();
            return batch;
        }

        public async Task<Batch> Update(Batch batch)
        {
            _context.Batches.Update(batch);
            await _context.SaveChangesAsync();
            return batch;
        }



        public async Task<bool> Delete(int id)
        {
            var batch = await _context.Batches.FindAsync(id);
            if (batch == null) return false;

            _context.Batches.Remove(batch);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
