namespace HomeBillings.Entradas.API.Domain.Commands.Parameters
{
    public class EntradaDeleteParameter : IRequest<ValidationResult>
    {
        public string Id { get; set; }
    }
}
