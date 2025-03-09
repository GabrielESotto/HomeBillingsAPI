
namespace HomeBillings.Entradas.API.Domain.Events
{
    public class EntryEventHandler : INotificationHandler<EntryNotificationEvent>
    {
        public Task Handle(EntryNotificationEvent notification, CancellationToken cancellationToken)
        {
            // Enviar notificação para usuário de entrada adicionada.
            throw new NotImplementedException();
        }
    }
}
