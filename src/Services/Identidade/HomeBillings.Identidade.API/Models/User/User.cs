using HomeBillings.Core;
using HomeBillings.Usuario.API.Domain.Entities;
using System.Text.Json.Serialization;

namespace HomeBillings.Identidade.API.Models
{
    public class User : DomainEntity, IAggregateRoot
    {
        [JsonConstructor]
        protected User() { }

        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string PersonRegister { get; set; }
        public PersonEnum Person { get; set; }
        public Address Address { get; set; }
        public Family Family { get; set; }
    }
}
