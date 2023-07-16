using Application.Contract.Address;
using DTOS.Address;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Addresses.Query.FilterAddress
{
    public class FilterAddressQueryHandler : IRequestHandler<FilterAddressQuery, IEnumerable<AddressMinimalDTO>>
    {
        private readonly IAddressRepository _addressRepository;

        public FilterAddressQueryHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public async Task<IEnumerable<AddressMinimalDTO>> Handle(FilterAddressQuery request, CancellationToken cancellationToken)
        {
            return (await _addressRepository.FilterByAsync(request.Address1, request.Address2, request.City, request.Country))
                          .Select(x => new AddressMinimalDTO()
                          {
                              Id = x.Id,
                              Address1 = x.Address1,
                              Address2 = x.Address2,
                              City = x.City,
                              Region = x.Region,
                              Country = x.Country,
                              PostCode = x.PostCode,
                              StreetNumber = x.StreetNumber,
                              UnitNumber = x.UnitNumber
                          });
        }
    }
}

