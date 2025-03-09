

namespace HomeBillings.Usuario.API.Domain.Commands.Parameters
{
    public class AddressAddParameter
    {
        public string StreetName { get; private set; }
        public int Number { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }
    }
}
