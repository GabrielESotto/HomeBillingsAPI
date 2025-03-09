using HomeBillings.Core;
using HomeBillings.Entradas.API.Domain.Commands.Interfaces;
using HomeBillings.Entradas.API.Domain.Commands.Parameters;
using HomeBillings.Entradas.API.Domain.Entities.Entrada;

namespace HomeBillings.Entradas.API.Domain.Commands.Handlers
{
    public class EntradaDeleteCommandHandler : IEntradaDeleteCommandHandler
    {
        private readonly IEntradaRepository _repository;
        public EntradaDeleteCommandHandler(IEntradaRepository repository)
        {
            _repository = repository;
        }

        public async Task<ValidationResult> Handle(EntradaDeleteParameter parameter, CancellationToken cancellationToken)
        {
            if (parameter == null)
                return null;

            var entry = await _repository.GetById(parameter.Id, cancellationToken);

            if (entry == null)
                return null;

            _repository.Delete(entry);

            return await _repository.SaveChanges(_repository.UnitOfWork);
        }
    }
}
