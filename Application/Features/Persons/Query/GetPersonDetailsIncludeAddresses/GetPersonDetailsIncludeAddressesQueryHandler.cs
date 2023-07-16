using Application.Contract.Person;
using Application.Features.Departments.Query.GetDepartmentDetailsIncludeEmployess;
using DTOS.Address;
using DTOS.Person;
using MediatR;

namespace Application.Features.Persons.Query.GetDepartmentDetailsIncludeEmployess
{
    public class GetPersonDetailsIncludeAddressesQueryHandler :
        IRequestHandler<GetPersonDetailsIncludeAddressesQuery, PersonDetailsWithAddressesDto>
    {
        private readonly IPersonRepository _personRepository;

       

        public GetPersonDetailsIncludeAddressesQueryHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<PersonDetailsWithAddressesDto> Handle(GetPersonDetailsIncludeAddressesQuery request, CancellationToken cancellationToken)
        {
            var user =await _personRepository.GetPersonWithAddresses(request.Id);
            if (user is null)
                throw new Exception("Not Found User");
            else return new PersonDetailsWithAddressesDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                UserName = user.UserName,
                Address = user.Addresses.Select(a => new AddressMinimalDTO
                {
                    Id = a.Id,
                    Address1 = a.Address1,
                    Address2 = a.Address2,
                    City = a.City,
                    Country = a.Country,
                    UnitNumber = a.UnitNumber,
                    PostCode = a.PostCode,
                    Region = a.Region,
                    StreetNumber = a.StreetNumber

                }).ToList()

            };


        }
    }
}

