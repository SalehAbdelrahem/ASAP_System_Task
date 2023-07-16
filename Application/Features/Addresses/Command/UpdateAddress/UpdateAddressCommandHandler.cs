using Application.Contract.Address;
using MediatR;

namespace Application.Features.Addesses.Commands.UpdateAddress
{
    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand, bool>
    {
        private readonly IAddressRepository _addressRepository;

        public UpdateAddressCommandHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public async Task<bool> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            var address = await _addressRepository.GetDetailsAsync(request.Id);
            if (address == null)
            {
                return false;
            }
            else
            {
                if (request.UnitNumber != null)
                    address.UnitNumber = request.UnitNumber;
                if (request.Address1 != null)
                    address.Address1 = request.Address1;
                if (request.Address2 != null)
                    address.Address2 = request.Address2;

                if (request.City != null)
                    address.City = request.City;
                if (request.Region != null)
                    address.Region = request.Region;
                if (request.Country != null)
                    address.Country = request.Country;
                if (request.PostCode != null)
                    address.PostCode = request.PostCode;
                if (request.StreetNumber != null)
                    address.StreetNumber = request.StreetNumber;

                return await _addressRepository.UpdateAsync(address);
            }
        }
    }
}
