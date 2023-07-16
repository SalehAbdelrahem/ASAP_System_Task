using DTOS.Person;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Features.Persons.Command.CreatePerson
{
    public class CreatePersonCommant : IRequest<PersonMinimalDto>
    {
        public CreatePersonCommant(string firstName, string lastName, string userName, string email, string passWord)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Email = email;
            PassWord = passWord;
        }

        public string FirstName { get; set; }
        [Required, MinLength(3), MaxLength(100)]
        public string LastName { get; set; }
        [Required, MinLength(3), MaxLength(100)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "The Email Must Match The Regular Expression"), DataType(DataType.EmailAddress), RegularExpression(@"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$")]

        public string Email { get; set; }
        public string PassWord { get; set; }
     
    }
}
