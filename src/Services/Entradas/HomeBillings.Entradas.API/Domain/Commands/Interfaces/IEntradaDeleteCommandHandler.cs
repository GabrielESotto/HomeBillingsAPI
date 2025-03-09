using HomeBillings.Entradas.API.Domain.Commands.Parameters;

namespace HomeBillings.Entradas.API.Domain.Commands.Interfaces
{
    public interface IEntradaDeleteCommandHandler : IRequestHandler<EntradaDeleteParameter, ValidationResult>
    {
    }
}
