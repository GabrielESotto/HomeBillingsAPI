using HomeBillings.Core;
using HomeBillings.Usuario.API.Domain.Commands.Parameters;
using System.Text.Json.Serialization;

namespace HomeBillings.Usuario.API.Domain.Entities
{
    public class Family : DomainEntity
    {
        [JsonConstructor]
        protected Family() { }

        public Family(string name, string description, FamilyTypeEnum type)
        {
            Name = name;
            Description = description;
            Type = type;
        }

        private Family(FamilyAddParameter parameter)
        {
            DefineName(parameter.Name);
            DefineDescription(parameter.Description);
            DefineType(parameter.Type);
            DefineCreatedIn();
        }

        public static Family Create(FamilyAddParameter parameter)
        {
            return new Family(parameter);
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public FamilyTypeEnum Type { get; set; }
        public DateTimeOffset CreatedIn { get; set; } = DateTimeOffset.Now;

        public ICollection<User>? Users { get; private set; }

        public void DefineName(string name)
            => Name = name;

        public void DefineDescription(string description)
            => Description = description;

        public void DefineType(FamilyTypeEnum type)
            => Type = type;

        public void DefineCreatedIn()
            => CreatedIn = DateTimeOffset.Now;
    }
}
