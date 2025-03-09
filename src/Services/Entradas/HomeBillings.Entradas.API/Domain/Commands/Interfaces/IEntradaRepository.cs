using HomeBillings.Entradas.API.Domain.Entities.Entrada;

namespace HomeBillings.Entradas.API.Domain.Commands.Interfaces
{
    public interface IEntradaRepository : IRepository<Entry>
    {
        Task<IEnumerable<Entry>> GetAll(CancellationToken cancellationToken);
        Task<Entry> GetById(string id, CancellationToken cancellationToken);
        Task Add(Entry entry, CancellationToken cancellationToken);
        void Update(Entry entry);
        void Delete(Entry id);
    }
}
