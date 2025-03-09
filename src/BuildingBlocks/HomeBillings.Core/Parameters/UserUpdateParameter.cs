using FluentValidation.Results;
using HomeBillings.Usuario.API.Domain.Entities;
using MediatR;

namespace HomeBillings.Usuario.API.Domain.Commands.Parameters
{
    public class UserUpdateParameter : IRequest<ValidationResult>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Address Address { get; set; }
        public Family Family { get; set; }
    }
}
