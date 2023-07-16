using Application.Contract.Person;
using DTOS.Person;
using MediatR;

namespace Application.Features.Persons.Query.GetAllPerson
{
    public class GetAllPersonQueryHandler : IRequestHandler<GetAllPersonQuery, IEnumerable<PersonMinimalDto>>
    {
        private readonly IPersonRepository _personRepository;

        public GetAllPersonQueryHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public async Task<IEnumerable<PersonMinimalDto>> Handle(GetAllPersonQuery request, CancellationToken cancellationToken)
        {
            return (await _personRepository.GetAllAsync()).Select(x =>
                new PersonMinimalDto
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    UserName = x.UserName,
                    Email = x.Email
                }
                );
        }
    }
}
