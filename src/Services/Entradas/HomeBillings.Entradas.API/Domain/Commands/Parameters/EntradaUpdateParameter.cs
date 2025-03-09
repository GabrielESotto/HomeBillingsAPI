using HomeBillings.Entradas.API.Domain.Entities.Categoria;

namespace HomeBillings.Entradas.API.Domain.Commands.Parameters
{
    public class EntradaUpdateParameter : IRequest<ValidationResult>
    {
        public string Id { get; set; }
        public Category Category { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
    }
}
