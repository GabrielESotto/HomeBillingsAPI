using HomeBillings.Entradas.API.Domain.Commands.Interfaces;
using HomeBillings.Entradas.API.Domain.Commands.Parameters;

namespace HomeBillings.Entradas.API.Domain.Commands.Handlers
{
    public class EntradaUpdateCommandHandler : IEntradaUpdateCommandHandler
    {
        private readonly IEntradaRepository _repository;
        public EntradaUpdateCommandHandler(IEntradaRepository repository)
        {
            _repository = repository;
        }

        public async Task<ValidationResult> Handle(EntradaUpdateParameter parameter, CancellationToken cancellationToken)
        {
            if (parameter == null)
                return null;

            var entry = await _repository.GetById(parameter.Id, cancellationToken);

            if (entry == null)
                return null;

            _repository.Update(entry);

            return await _repository.SaveChanges(_repository.UnitOfWork);
        }
    }
}
