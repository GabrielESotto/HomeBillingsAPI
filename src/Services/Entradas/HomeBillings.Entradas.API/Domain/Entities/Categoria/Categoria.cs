using HomeBillings.Entradas.API.Domain.Entities.Entrada;

namespace HomeBillings.Entradas.API.Domain.Entities.Categoria
{
    public class Category : DomainEntity
    {
        protected Category () { }

        public Category(string name, string description, string acronym, DateTimeOffset createdIn)
        {
            DefineName(name);
            DefineDescription(description);
            DefineAcronym(acronym);
            DefineCreatedIn(createdIn);
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Acronym { get; private set; }
        public DateTimeOffset CreatedIn { get; private set; }

        public virtual ICollection<Entry> Entries { get; private set; }

        public void DefineName(string name)
            => Name = name;

        public void DefineDescription(string description)
            => Description = description;

        public void DefineAcronym(string acronym)
            => Acronym = acronym;

        public void DefineCreatedIn(DateTimeOffset createdIn)
            => CreatedIn = createdIn;
    }
}
