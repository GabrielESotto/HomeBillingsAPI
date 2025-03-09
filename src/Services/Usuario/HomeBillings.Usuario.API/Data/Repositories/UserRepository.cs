using FluentValidation.Results;
using HomeBillings.Entradas.API.Data.Context;
using HomeBillings.Usuario.API.Domain.Commands.Interfaces;
using HomeBillings.Usuario.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeBillings.Usuario.API.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;

        public UserRepository(UserContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<IEnumerable<User>> GetAll(CancellationToken cancellationToken)
        {
            return await _context.Users.AsNoTracking().ToListAsync();
        }

        public async Task<User> GetById(string id, CancellationToken cancellationToken)
        {
            return await _context.Users.FindAsync(id, cancellationToken);
        }

        public async Task<bool> ExistsByEmail(string email)
        {
            return _context.Users.Where(x => x.Email == email).Any();
        }

        public async Task Add(User user, CancellationToken cancellationToken)
        {
            await _context.Users.AddAsync(user, cancellationToken);
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
        }

        public void Delete(User user)
        {
            _context.Users.Remove(user);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<ValidationResult> SaveChanges(IUnitOfWork uow)
        {
            if (!await uow.Commit()) return null;

            return new ValidationResult();
        }
    }
}
