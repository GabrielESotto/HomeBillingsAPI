using System.Text.Json.Serialization;

namespace HomeBillings.Core
{
    public class DomainEntity
    {
        public DomainEntity()
        {
            Id = Guid.NewGuid().ToString();
        }

        [JsonIgnore]
        public string Id { get; set; }

        private List<Event> _notifications;
        public IReadOnlyCollection<Event>? Notifications => _notifications?.AsReadOnly();

        public void AddEvent(Event evento)
        {
            _notifications = _notifications ?? new List<Event>();
            _notifications.Add(evento);
        }

        public void RemoveEvent(Event eventItem)
        {
            _notifications.Remove(eventItem);
        }

        public void ClearEvents()
        {
            _notifications.Clear();
        }
    }
}
