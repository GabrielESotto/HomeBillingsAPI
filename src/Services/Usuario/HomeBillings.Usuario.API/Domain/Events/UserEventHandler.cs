
namespace HomeBillings.Usuario.API.Domain.Events
{
    public class UserEventHandler : INotificationHandler<UserRegisteredEvent>
    {
        public Task Handle(UserRegisteredEvent notification, CancellationToken cancellationToken)
        {
            // Enviar email de confirmação de registro
            return Task.WhenAll();
        }
    }
}
