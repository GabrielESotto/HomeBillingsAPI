using FluentValidation.Results;
using HomeBillings.Usuario.API.Domain.Commands.Interfaces;
using HomeBillings.Usuario.API.Domain.Commands.Parameters;
using HomeBillings.Usuario.API.Domain.Entities;
using HomeBillings.Usuario.API.Domain.Events;

namespace HomeBillings.Usuario.API.Domain.Commands.Handlers
{
    public class UserAddCommandHandler : IUserAddCommandHandler
    {
        private readonly IUserRepository _repository;

        public UserAddCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<ValidationResult> Handle(UserAddParameter parameter, CancellationToken cancellationToken)
        {
            if (parameter == null)
                return null;

            var user = User.Create(parameter);

            var userExists = await _repository.ExistsByEmail(parameter.Email);

            if (userExists)
                return null;

            await _repository.Add(user, cancellationToken);

            user.AddEvent(new UserRegisteredEvent(user.Id, user.Name, user.LastName, user.Email));

            return await _repository.SaveChanges(_repository.UnitOfWork);
        }
    }
}
