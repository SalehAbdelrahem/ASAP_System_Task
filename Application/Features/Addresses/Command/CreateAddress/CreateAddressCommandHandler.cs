using Application.Contract.Address;
using Application.Contract.Person;
using Domain;
using DTOS.Address;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Addresses.Command.CreateAddress
{
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, AddressMinimalDTO>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IPersonRepository _personRepositor;
        private readonly UserManager<Person> _userManager;



        public CreateAddressCommandHandler(IAddressRepository addressRepository
            , IPersonRepository personRepositor
            , UserManager<Person> userManager)
        {
            _addressRepository = addressRepository;
            _personRepositor = personRepositor;
            _userManager = userManager;
        }
        public async Task<AddressMinimalDTO> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            var user1 = await _personRepositor.GetDetailsAsync(request.UserId);
          
            if (user1 == null)
            {
                throw new Exception("not found user");
            }

            Address AddressTemp = new Address()
            {
                UnitNumber = request.UnitNumber,
                Address1 = request.Address1,
                Address2 = request.Address2,
                City = request.City,
                Region = request.Region,
                Country = request.Country,
                PostCode = request.PostCode,
                StreetNumber = request.StreetNumber,
                Person=user1

            };

            var address = await _addressRepository.CreateAsync(AddressTemp);
          
            return new AddressMinimalDTO()
            {
                Id = address.Id,
                UnitNumber = address.UnitNumber,
                Address1 = address.Address1,
                Address2 = address.Address2,
               
                City = address.City,
                Region = address.Region,
                Country = address.Country,
                PostCode = address.PostCode,
                StreetNumber = address.StreetNumber,

            };
        }
    }
}
