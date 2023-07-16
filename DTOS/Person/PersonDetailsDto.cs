namespace DTOS.Person
{
    public class PersonDetailsDto
    {

        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }
        public PersonDetailsDto(string firstName, string lastName, string userName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Email = email;
        }
        public PersonDetailsDto()
        {

        }
    }
}
