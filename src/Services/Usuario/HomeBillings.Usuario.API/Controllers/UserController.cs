using HomeBillings.Usuario.API.Domain.Commands.Interfaces;
using HomeBillings.Usuario.API.Domain.Commands.Parameters;
using HomeBillings.Usuario.API.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace HomeBillings.Usuario.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMediator _mediator;

        public UserController(ILogger<UserController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetAll([FromServices] IUserRepository repository, CancellationToken cancellationToken)
        {
            return await repository.GetAll(cancellationToken);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<User> GetById([FromServices] IUserRepository repository, string id, CancellationToken cancellationToken)
        {
            return await repository.GetById(id, cancellationToken);
        }

        [HttpPost]
        public async Task Add([FromBody] UserAddParameter parameter, CancellationToken cancellationToken)
        {
            await _mediator.Send(parameter, cancellationToken);
        }

        [HttpPut]
        public async Task Update([FromBody] UserUpdateParameter parameter, CancellationToken cancellationToken)
        {
            await _mediator.Send(parameter, cancellationToken);
        }

        [HttpDelete]
        public async Task Delete([FromQuery] UserDeleteParameter parameter, CancellationToken cancellationToken)
        {
            await _mediator.Send(parameter, cancellationToken);
        }
    }
}
