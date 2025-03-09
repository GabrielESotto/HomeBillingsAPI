using HomeBillings.Core;
using HomeBillings.Entradas.API.Domain.Commands.Interfaces;
using HomeBillings.Entradas.API.Domain.Commands.Parameters;
using HomeBillings.Entradas.API.Domain.Entities.Entrada;
using HomeBillings.Entradas.API.Domain.Events;

namespace HomeBillings.Entradas.API.Domain.Commands.Handlers
{
    public class EntradaAddCommandHandler : IEntradaAddCommandHandler
    {
        private readonly IEntradaRepository _repository;
        public EntradaAddCommandHandler(IEntradaRepository repository)
        {
            _repository = repository;
        }

        public async Task<ValidationResult> Handle(EntradaAddParameter parameter, CancellationToken cancellationToken)
        {
            if (parameter == null)
                return null;

            var entry = new Entry(parameter);

            if (entry == null)
                return null;

            await _repository.Add(entry, cancellationToken);

            entry.AddEvent(new EntryNotificationEvent(entry.Id, entry.Description, entry.Value, entry.Category));

            return await _repository.SaveChanges(_repository.UnitOfWork);
        }
    }
}
