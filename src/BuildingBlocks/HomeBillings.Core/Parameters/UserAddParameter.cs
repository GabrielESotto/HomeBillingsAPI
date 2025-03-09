using FluentValidation.Results;
using HomeBillings.Usuario.API.Domain.Entities;
using MediatR;

namespace HomeBillings.Usuario.API.Domain.Commands.Parameters
{
    public class UserAddParameter : IRequest<ValidationResult>
    {
        public UserAddParameter(string name, string lastName, DateTime birthDate, string email, string phoneNumber, 
            PersonEnum person, string personRegister, Address address, Family family)
        {
            Name = name;
            LastName = lastName;
            BirthDate = birthDate;
            Email = email;
            PhoneNumber = phoneNumber;
            Person = person;
            PersonRegister = personRegister;
            Address = address;
            Family = family;
        }

        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public PersonEnum Person { get; set; }
        public string PersonRegister { get; set; }
        public Address Address { get; set; }
        public Family Family { get; set; }
    }
}
