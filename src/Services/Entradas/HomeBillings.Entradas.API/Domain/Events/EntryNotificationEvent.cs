using HomeBillings.Entradas.API.Domain.Entities.Categoria;

namespace HomeBillings.Entradas.API.Domain.Events
{
    public class EntryNotificationEvent : Event
    {
        public string Id { get; private set; }
        public string Description { get; private set; }
        public decimal Value { get; private set; }
        public Category Category { get; private set; }

        public EntryNotificationEvent(string id, string description, decimal value, Category category)
        {
            AggregateId = id;
            Id = id;
            Description = description;
            Value = value;
            Category = category;
        }
    }
}
