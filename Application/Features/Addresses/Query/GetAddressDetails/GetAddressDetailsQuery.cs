
using DTOS.Address;
using MediatR;

namespace Application.Features.Addresses.Query.GetAddressDetails
{
    public class GetAddressDetailsQuery : IRequest<AddressMinimalDTO>
    {
        public int Id { get; set; }
    }
}
