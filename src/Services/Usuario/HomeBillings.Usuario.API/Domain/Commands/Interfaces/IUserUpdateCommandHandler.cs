using FluentValidation.Results;
using HomeBillings.Usuario.API.Domain.Commands.Parameters;

namespace HomeBillings.Usuario.API.Domain.Commands.Interfaces
{
    public interface IUserUpdateCommandHandler : IRequestHandler<UserUpdateParameter, ValidationResult>
    {
    }
}
