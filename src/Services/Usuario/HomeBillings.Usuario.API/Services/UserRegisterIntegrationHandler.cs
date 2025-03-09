
using AutoMapper;
using EasyNetQ;
using FluentValidation.Results;
using HomeBillings.Core.Integration;
using HomeBillings.Usuario.API.Domain.Commands.Parameters;

namespace HomeBillings.Usuario.API.Services
{
    public class UserRegisterIntegrationHandler : BackgroundService
    {
        private IBus _bus;
        private readonly IMapper _mapper;
        private readonly IServiceProvider _serviceProvider;

        public UserRegisterIntegrationHandler(IServiceProvider serviceProvider, IMapper mapper)
        {
            _serviceProvider = serviceProvider;
            _mapper = mapper;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _bus = RabbitHutch.CreateBus(connectionString: "host=localhost:5672");
            _bus.Rpc.RespondAsync<UserRegisteredIntegrationEvent, ResponseMessage>(async request =>
                new ResponseMessage(await RegisterUser(request)));

            return Task.CompletedTask;
        }

        private async Task<ValidationResult> RegisterUser(UserRegisteredIntegrationEvent message)
        {
            ValidationResult success;
            try
            {
                var userParameter = new UserAddParameter(message.Name, message.LastName, message.BirthDate, message.Email, message.PhoneNumber,
                    message.Person, message.PersonRegister, message.Address, message.Family);

                using (var scope = _serviceProvider.CreateScope())
                {
                    var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

                    success = await mediator.Send(userParameter);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return success;
        }
    }
}
