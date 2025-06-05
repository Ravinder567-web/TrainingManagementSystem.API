using TrainingManagementSystem.API.Models;

namespace TrainingManagementSystem.API.Repositories
{
    public interface IEnrolmentRepository
    {
        Task<IEnumerable<Enrolment>> GetAll();
        Task<Enrolment> GetById(int id);
        Task<IEnumerable<Enrolment>> GetByManager(int managerId);
        Task<IEnumerable<Enrolment>> GetByUser(int userId);
        Task<Enrolment> RequestEnrolment(int userId, int batchId);
        Task<Enrolment> ApproveOrReject(int id, string status);
    }

}
