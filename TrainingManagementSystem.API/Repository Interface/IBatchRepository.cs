using TrainingManagementSystem.API.Models;

namespace TrainingManagementSystem.API.Services
{
    public interface IBatchRepository
    {
        Task<IEnumerable<Batch>> GetAll();
        Task<Batch> GetById(int id);
        Task<Batch> Add(Batch batch);
        Task<Batch> Update(Batch batch);
        Task<bool> Delete(int id);
    }
}
