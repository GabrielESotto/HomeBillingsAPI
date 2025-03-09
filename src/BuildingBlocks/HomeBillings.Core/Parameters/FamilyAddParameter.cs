using HomeBillings.Usuario.API.Domain.Entities;

namespace HomeBillings.Usuario.API.Domain.Commands.Parameters
{
    public class FamilyAddParameter
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public FamilyTypeEnum Type { get; private set; }
    }
}
