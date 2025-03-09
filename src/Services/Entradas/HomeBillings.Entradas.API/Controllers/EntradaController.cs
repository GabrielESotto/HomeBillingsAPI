using HomeBillings.Entradas.API.Domain.Commands.Interfaces;
using HomeBillings.Entradas.API.Domain.Commands.Parameters;
using HomeBillings.Entradas.API.Domain.Entities.Entrada;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace HomeBillings.Entradas.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EntradaController : ControllerBase
    {
        private readonly ILogger<EntradaController> _logger;
        private readonly IMediator _mediator;

        public EntradaController(ILogger<EntradaController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<Entry>> GetAll([FromServices] IEntradaRepository repository, CancellationToken cancellationToken)
        {
            return await repository.GetAll(cancellationToken);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Entry> GetById([FromServices] IEntradaRepository repository, string id, CancellationToken cancellationToken)
        {
            return await repository.GetById(id, cancellationToken);
        }

        [HttpPost]
        public async Task Add([FromBody] EntradaAddParameter parameter, CancellationToken cancellationToken)
        {
            var response = _mediator.Send(parameter, cancellationToken);
        }

        [HttpPut]
        public async Task Update([FromBody] EntradaUpdateParameter parameter, CancellationToken cancellationToken)
        {
            var response = _mediator.Send(parameter, cancellationToken);
        }

        [HttpDelete]
        public async Task Delete([FromQuery] string id, CancellationToken cancellationToken)
        {
            var response = _mediator.Send(id, cancellationToken);
        }
    }
}
