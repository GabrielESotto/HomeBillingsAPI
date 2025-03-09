using FluentValidation.Results;
using MediatR;

namespace HomeBillings.Usuario.API.Domain.Commands.Parameters
{
    public class UserDeleteParameter : IRequest<ValidationResult>
    {
        public string Id { get; set; }
    }
}
