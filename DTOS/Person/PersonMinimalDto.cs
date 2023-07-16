using System.ComponentModel.DataAnnotations;

namespace DTOS.Person
{
    public class PersonMinimalDto
    {
       
        [Required, MinLength(3), MaxLength(100)]
        public string FirstName { get; set; }
        [Required, MinLength(3), MaxLength(100)]
        public string LastName { get; set; }
        [Required, MinLength(3), MaxLength(100)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "The Email Must Match The Regular Expression"), DataType(DataType.EmailAddress), RegularExpression(@"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$")]

        public string Email { get; set; }
        public PersonMinimalDto(string firstName, string lastName, string userName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Email = email;
        }
        public PersonMinimalDto() : this(null!, null!, null!,null!)
        {
        }
    }
}
