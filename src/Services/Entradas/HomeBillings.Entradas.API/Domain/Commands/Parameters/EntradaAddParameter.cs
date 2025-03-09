using HomeBillings.Entradas.API.Domain.Entities.Categoria;

namespace HomeBillings.Entradas.API.Domain.Commands.Parameters
{
    public class EntradaAddParameter : IRequest<ValidationResult>
    {
        public Category Category { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
    }
}
