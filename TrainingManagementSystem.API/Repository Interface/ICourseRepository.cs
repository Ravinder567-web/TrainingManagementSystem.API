using TrainingManagementSystem.API.DTOs;
using TrainingManagementSystem.API.Models;

namespace TrainingManagementSystem.API.Repositories
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAll();
        Task<Course> GetById(int id);
        Task<Course> Add(Course course);
        Task<Course> Update(Course course);
        Task<bool> Delete(int id);
        T Map<T>(CourseDTO dto);
    }
}
