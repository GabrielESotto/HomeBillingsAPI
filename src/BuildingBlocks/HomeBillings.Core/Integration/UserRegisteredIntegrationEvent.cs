using HomeBillings.Usuario.API.Domain.Entities;

namespace HomeBillings.Core.Integration
{
    public class UserRegisteredIntegrationEvent : IntegrationEvent
    {
        public UserRegisteredIntegrationEvent(string id, string name, string lastName, DateTime birthDate,
            string email, string phoneNumber, string personRegister, PersonEnum person, Address address, Family family)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            BirthDate = birthDate;
            Email = email;
            PhoneNumber = phoneNumber;
            PersonRegister = personRegister;
            Person = person;
            Address = address;
            Family = family;
        }

        public string Id { get; private set; }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string ConfirmPassword { get; private set; }
        public string PhoneNumber { get; private set; }
        public PersonEnum Person { get; set; }
        public string PersonRegister { get; private set; }
        public Address Address { get; private set; }
        public Family Family { get; private set; }
    }
}
