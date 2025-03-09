using HomeBillings.Usuario.API.Domain.Entities;

namespace HomeBillings.Usuario.API.Domain.Commands.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<IEnumerable<User>> GetAll(CancellationToken cancellationToken);
        Task<User> GetById(string id, CancellationToken cancellationToken);
        Task<bool> ExistsByEmail(string email);
        Task Add(User user, CancellationToken cancellationToken);
        void Update(User user);
        void Delete(User user);
    }
}
