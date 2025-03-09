using HomeBillings.Entradas.API.Domain.Commands.Parameters;
using HomeBillings.Entradas.API.Domain.Entities.Categoria;

namespace HomeBillings.Entradas.API.Domain.Entities.Entrada
{
    public class Entry : DomainEntity, IAggregateRoot
    {
        protected Entry() { }

        public Entry(EntradaAddParameter parameter)
        {
            DefineCategory(parameter.Category);
            DefineDescription(parameter.Description);
            DefineValue(parameter.Value);
            DefineEntryDate();
        }

        public string CategoryId { get; private set; }
        public string Description { get; private set; }
        public decimal Value { get; private set; }
        public DateTimeOffset EntryDate { get; private set; }

        public virtual Category Category { get; private set; }


        public void Update(EntradaUpdateParameter parameter)
        {
            DefineCategory(parameter.Category);
            DefineDescription(parameter.Description);
            DefineValue(parameter.Value);
        }

        public void DefineCategory(Category category)
            => Category = category;

        public void DefineDescription(string description)
            => Description = description;

        public void DefineValue(decimal value)
            => Value = value;

        public void DefineEntryDate()
            => EntryDate = DateTimeOffset.UtcNow;
    }
}
