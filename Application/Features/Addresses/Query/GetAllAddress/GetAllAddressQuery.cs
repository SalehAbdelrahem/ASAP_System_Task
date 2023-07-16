using DTOS.Address;
using MediatR;

namespace Application.Features.Addresses.Query.GetAllAddress
{
    public class GetAllAddressQuery : IRequest<IEnumerable<AddressMinimalDTO>>
    {
        public string UserId { get; set; }
    }
}
