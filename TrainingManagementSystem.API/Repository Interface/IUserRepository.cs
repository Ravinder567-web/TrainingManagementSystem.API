using TrainingManagementSystem.API.Models;

namespace TrainingManagementSystem.API.Repository_Interface
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(int id);
        Task<User> Add(User user);
        Task<User> Update(User user);
        Task<bool> Delete(int id);
        Task<User> GetByUsername(string username);
    }

}
