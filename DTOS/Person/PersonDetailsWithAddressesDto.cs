using DTOS.Address;

namespace DTOS.Person
{
    public class PersonDetailsWithAddressesDto
    {

        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public List<AddressMinimalDTO>? Address { get; set; }
        public PersonDetailsWithAddressesDto(string firstName, string lastName, string userName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Email = email;
            Address = new List<AddressMinimalDTO>();
          
        }
        public PersonDetailsWithAddressesDto()
        {

        }
    }
}
