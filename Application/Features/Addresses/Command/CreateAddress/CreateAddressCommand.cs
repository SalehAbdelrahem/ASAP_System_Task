using DTOS.Address;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Features.Addresses.Command.CreateAddress

{
    public class CreateAddressCommand : IRequest<AddressMinimalDTO>
    {
        public string UserId { get; set; }

        [MaxLength(10)]
        public string? UnitNumber { get; set; }
        [MaxLength(100)]
        public string? StreetNumber { get; set; }
        [MaxLength(200), MinLength(5)]
        public string Address1 { get; set; }
        [MaxLength(200), MinLength(5)]
        public string? Address2 { get; set; }

        
        [MaxLength(100), MinLength(3)]
        public string City { get; set; }
        [MaxLength(50), MinLength(3)]
        public string Region { get; set; }
        [MaxLength(10), MinLength(5)]
        public string? PostCode { get; set; }
        [MaxLength(100), MinLength(5)]
        public string Country { get; set; }
        public CreateAddressCommand() : this(null, null, null!, null, null!, null!, null, null!)
        {

        }

        public CreateAddressCommand(string? unitNumber, string? streetNumber, string address1, string? address2, string city, string region, string? postCode, string country)
        {
            UnitNumber = unitNumber;
            StreetNumber = streetNumber;
            Address1 = address1;
            Address2 = address2;
          
            City = city;
            Region = region;
            PostCode = postCode;
            Country = country;
        }
    }
}
