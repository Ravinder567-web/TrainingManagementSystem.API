using System;
using Microsoft.EntityFrameworkCore;
using TrainingManagementSystem.API.Data;
using TrainingManagementSystem.API.Models;
using TrainingManagementSystem.API.Repositories;

public class EnrolmentRepository : IEnrolmentRepository
{
    private readonly ApplicationDbContext _context;

    public EnrolmentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Enrolment>> GetAll()
    {
        return await _context.Enrolments
            .Include(e => e.User)
            .Include(e => e.Batch)
            .ToListAsync();
    }

    public async Task<Enrolment?> GetById(int id)
    {
        return await _context.Enrolments
            .Include(e => e.User)
            .Include(e => e.Batch)
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<Enrolment> Create(Enrolment enrolment)
    {
        _context.Enrolments.Add(enrolment);
        await _context.SaveChangesAsync();
        return enrolment;
    }

    public async Task<Enrolment?> Update(Enrolment enrolment)
    {
        var existing = await _context.Enrolments.FindAsync(enrolment.Id);
        if (existing == null)
            return null;

        existing.Status = enrolment.Status;
        existing.BatchId = enrolment.BatchId;
        existing.UserId = enrolment.UserId;

        await _context.SaveChangesAsync();
        return existing;
    }

    public async Task<bool> Delete(int id)
    {
        var enrolment = await _context.Enrolments.FindAsync(id);
        if (enrolment == null)
            return false;

        _context.Enrolments.Remove(enrolment);
        await _context.SaveChangesAsync();
        return true;
    }
}
