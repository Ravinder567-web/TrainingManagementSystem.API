using TrainingManagementSystem.API.Models;

namespace TrainingManagementSystem.API.Repositories
{
    public interface IEnrolmentRepository
{
    Task<IEnumerable<Enrolment>> GetAll();
    Task<Enrolment?> GetById(int id);
    Task<Enrolment> Create(Enrolment enrolment);
    Task<Enrolment?> Update(Enrolment enrolment);
    Task<bool> Delete(int id);
}

}
