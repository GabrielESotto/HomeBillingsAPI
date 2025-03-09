using HomeBillings.Core;
using HomeBillings.Usuario.API.Domain.Commands.Parameters;
using System.Text.Json.Serialization;

namespace HomeBillings.Usuario.API.Domain.Entities
{
    public class Address : DomainEntity, IAggregateRoot
    {
        [JsonConstructor]
        protected Address() { }

        public Address(string streetName, int number, string neighborhood, string city, string state, string zipCode)
        {
            StreetName = streetName;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            ZipCode = zipCode;
        }

        private Address(AddressAddParameter parameter)
        {
            DefineStreetName(parameter.StreetName);
            DefineNumber(parameter.Number);
            DefineNeighborhood(parameter.Neighborhood);
            DefineCity(parameter.City);
            DefineState(parameter.State);
            DefineZipCode(parameter.ZipCode);
        }

        public static Address Create(AddressAddParameter parameter)
        {
            return new Address(parameter);
        }

        public string StreetName { get; set; }
        public int Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public void DefineStreetName(string streetName)
            => StreetName = streetName;

        public void DefineNumber(int number)
            => Number = number;

        public void DefineNeighborhood(string neighborhood)
            => Neighborhood = neighborhood;

        public void DefineCity(string city)
            => City = city;

        public void DefineState(string state)
            => State = state;

        public void DefineZipCode(string zipCode)
            => ZipCode = zipCode;
    }
}
