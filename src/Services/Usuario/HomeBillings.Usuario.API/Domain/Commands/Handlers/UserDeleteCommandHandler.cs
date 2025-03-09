using FluentValidation.Results;
using HomeBillings.Usuario.API.Domain.Commands.Interfaces;
using HomeBillings.Usuario.API.Domain.Commands.Parameters;

namespace HomeBillings.Usuario.API.Domain.Commands.Handlers
{
    public class UserDeleteCommandHandler : IUserDeleteCommandHandler
    {
        private readonly IUserRepository _repository;
        public UserDeleteCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<ValidationResult> Handle(UserDeleteParameter parameter, CancellationToken cancellationToken)
        {
            if (parameter == null)
                return null;

            var user = await _repository.GetById(parameter.Id, cancellationToken);

            if (user == null)
                return null;

            _repository.Delete(user);

            return await _repository.SaveChanges(_repository.UnitOfWork);
        }
    }
}
