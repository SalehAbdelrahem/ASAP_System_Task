using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Domain
{
    public class Address
    {
      

        public int Id { get; set; }
        [MaxLength(10)]
        public string? UnitNumber { get; set; }
        [MaxLength(100)]
        public string? StreetNumber { get; set; }
        [MaxLength(200), MinLength(5)]
        public string Address1 { get; set; }
        [MaxLength(200), MinLength(5)]
        public string? Address2 { get; set; }
        [MaxLength(200), MinLength(5)]

        public string City { get; set; }
        [MaxLength(50), MinLength(3)]
        public string Region { get; set; }
        [MaxLength(10), MinLength(5)]
        public string? PostCode { get; set; }
        [MaxLength(100), MinLength(3)]
        public string Country { get; set; }



        public virtual Person Person { get; set; }

        public Address(string address1, string address2, string city, string region , string? unitNumber, string? streetNumber, string? postCode, string country, Person person)
        {
            UnitNumber = unitNumber;
            StreetNumber = streetNumber;
            Address1 = address1;
            Address2 = address2;
            City = city;
            Region = region;
            PostCode = postCode;
            Country = country;
            Person = person;
        }

        public Address() 
        {
        }

    }

}