using HomeBillings.Entradas.API.Data.Context;
using HomeBillings.Entradas.API.Domain.Commands.Interfaces;
using HomeBillings.Entradas.API.Domain.Entities.Entrada;
using Microsoft.EntityFrameworkCore;

namespace HomeBillings.Entradas.API.Data.Repositories
{
    public class EntradaRepository : IEntradaRepository
    {
        private readonly EntryContext _context;

        public EntradaRepository(EntryContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<IEnumerable<Entry>> GetAll(CancellationToken cancellationToken)
        {
            return await _context.Entries.AsNoTracking().ToListAsync();
        }

        public async Task<Entry> GetById(string id, CancellationToken cancellationToken)
        {
            return await _context.Entries.FindAsync(id, cancellationToken);
        }

        public async Task Add(Entry entry, CancellationToken cancellationToken)
        {
            await _context.Entries.AddAsync(entry, cancellationToken);
        }

        public void Update(Entry entry)
        {
            _context.Entries.Update(entry);
        }

        public void Delete(Entry entry)
        {
            _context.Entries.Remove(entry);
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
