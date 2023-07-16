using Application.Contract.Person;
using DTOS.Person;
using MediatR;

namespace Application.Features.Persons.Query.GetPersonDetails
{
    public class GetPersonDetailsQueryHandler: IRequestHandler<GetPersonDetailsQuery,PersonDetailsDto>
    {
        private readonly IPersonRepository _personRepository;

        public GetPersonDetailsQueryHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public async Task<PersonDetailsDto> Handle(GetPersonDetailsQuery request, CancellationToken cancellationToken)
        {
            var user = await _personRepository.GetDetailsAsync(request.Id);
            if (user == null)
            {
                throw new Exception("Not Found Person");
            }
            else
            {
                return new PersonDetailsDto
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserName = user.UserName,
                    Email = user.Email
                };
            }
           
        }
    }
}
