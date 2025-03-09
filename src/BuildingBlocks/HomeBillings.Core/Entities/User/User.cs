using HomeBillings.Core;
using HomeBillings.Usuario.API.Domain.Commands.Parameters;

namespace HomeBillings.Usuario.API.Domain.Entities
{
    public class User : DomainEntity, IAggregateRoot
    {
        protected User() { }

        private User(UserAddParameter parameter)
        {
            DefineName(parameter.Name);
            DefineLastName(parameter.LastName);
            DefineBirthDate(parameter.BirthDate);
            DefineAge(parameter.BirthDate);
            DefineEmail(parameter.Email);
            DefinePhoneNumber(parameter.PhoneNumber);
            DefinePerson(parameter.Person);
            DefinePersonRegister(parameter.PersonRegister);
            DefineAddress(parameter.Address);
            DefineAddressId(parameter.Address.Id);
            DefineFamily(parameter.Family);
            DefineFamilyId(parameter.Family.Id);
        }

        public static User Create(UserAddParameter parameter)
        {
            return new User(parameter);
        }

        public string Name { get; private set; }
        public string LastName { get; private set; }
        public DateTime BirthDate { get; private set; }
        public int Age { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public PersonEnum Person { get; private set; }
        public string PersonRegister { get; private set; }
        public virtual string AddressId { get; private set; }
        public virtual Address Address { get; private set; }
        public virtual string FamilyId { get; private set; }
        public virtual Family Family { get; private set; }

        public void Update(UserUpdateParameter parameter)
        {
            DefineName(parameter.Name);
            DefineLastName(parameter.LastName);
            DefineBirthDate(parameter.BirthDate);
            DefineAge(parameter.BirthDate);
            DefineEmail(parameter.Email);
            DefinePhoneNumber(parameter.PhoneNumber);
            DefineAddress(parameter.Address);
            DefineFamily(parameter.Family);
        }

        public void DefineName(string name)
            => Name = name;

        public void DefineLastName(string lastName)
            => LastName = lastName;

        public void DefineBirthDate(DateTime birthDate)
            => BirthDate = birthDate;

        public void DefineAge(DateTime birthDate)
            => Age = (int)((DateTime.Now - birthDate).TotalDays / 365.242199);

        public void DefineEmail(string email)
            => Email = email;

        public void DefinePhoneNumber(string phoneNumber)
            => PhoneNumber = phoneNumber;

        public void DefinePerson(PersonEnum person)
            => Person = person;

        public void DefinePersonRegister(string personRegister)
            => PersonRegister = personRegister;

        public void DefineAddress(Address address)
            => Address = address;

        public void DefineAddressId(string addressId)
            => AddressId = addressId;

        public void DefineFamily(Family family)
            => Family = family;

        public void DefineFamilyId(string familyId)
            => FamilyId = familyId;
    }
}
