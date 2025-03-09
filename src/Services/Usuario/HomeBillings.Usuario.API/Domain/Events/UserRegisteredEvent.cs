namespace HomeBillings.Usuario.API.Domain.Events
{
    public class UserRegisteredEvent : Event
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }

        public UserRegisteredEvent(string id, string name, string lastName, string email)
        {
            AggregateId = id;
            Id = id;
            Name = name;
            LastName = lastName;
            Email = email;
        }
    }
}
