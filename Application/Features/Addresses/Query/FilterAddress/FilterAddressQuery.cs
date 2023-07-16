using DTOS.Address;
using MediatR;

namespace Application.Features.Addresses.Query.FilterAddress
{
    public class FilterAddressQuery : IRequest<IEnumerable<AddressMinimalDTO>>
    {
        public string? Address1 { get; set; }

        public string? Address2 { get; set; }

        public string? City { get; set; }

        public string? Country { get; set; }
    }
}
