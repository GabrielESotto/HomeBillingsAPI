using FluentValidation.Results;
using HomeBillings.Usuario.API.Domain.Commands.Interfaces;
using HomeBillings.Usuario.API.Domain.Commands.Parameters;

namespace HomeBillings.Usuario.API.Domain.Commands.Handlers
{
    public class UserUpdateCommandHandler : IUserUpdateCommandHandler
    {
        private readonly IUserRepository _repository;
        public UserUpdateCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<ValidationResult> Handle(UserUpdateParameter parameter, CancellationToken cancellationToken)
        {
            if (parameter == null)
                return null;

            var user = await _repository.GetById(parameter.Id, cancellationToken);

            if (user == null)
                return null;

            user.Update(parameter);
            _repository.Update(user);

            return await _repository.SaveChanges(_repository.UnitOfWork);
        }
    }
}
