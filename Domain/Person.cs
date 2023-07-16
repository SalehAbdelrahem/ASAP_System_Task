using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Person : IdentityUser
    {
        [MaxLength(100), MinLength(3)]
        public string FirstName { get; set; }
        [MaxLength(100), MinLength(3)]
        public string LastName { get; set; }


        public virtual ICollection<Address> Addresses { get; set; }

        public Person(string firstName, string lastName)
        {
            Addresses = new List<Address>();
        }

        public Person(string firstName, string lastName, ICollection<Address> addresses)
        {
            FirstName = firstName;
            LastName = lastName;
            Addresses = addresses;
        }
        public Person()
        {

        }
    }
}
