using Microsoft.EntityFrameworkCore;
using TrainingManagementSystem.API.Data;
using TrainingManagementSystem.API.DTOs;
using TrainingManagementSystem.API.Models;
using TrainingManagementSystem.API.Repositories;

namespace TrainingManagementSystem.API.Services
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _context;

        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Course>> GetAll() => await _context.Courses.ToListAsync();

        public async Task<Course> GetById(int id) => await _context.Courses.FindAsync(id);

        public async Task<Course> Add(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return course;
        }

        public async Task<Course> Update(Course course)
        {
            _context.Entry(course).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return course;
        }

        public async Task<bool> Delete(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null) return false;
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return true;
        }

        public T Map<T>(CourseDTO dto)
        {
            throw new NotImplementedException();
        }
    }

}
