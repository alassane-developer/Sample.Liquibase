using Core.Entitties;

namespace Core.Contracts
{
    public interface IUserRepository
    {
        Task<User?> Get(string name);
        Task<User?> Get(Guid id);
        Task<IEnumerable<User>> GetAll();
        Task Add(User user);
        Task Update(User user);
        Task Delete(Guid id);
    }
}