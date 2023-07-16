using Application.Contract.Address;
using Application.Contract.Person;
using DTOS.Address;
using DTOS.Person;
using MediatR;

namespace Application.Features.Persons.Query.FilterPerson
{
    public class FilterPersonQueryHandler : IRequestHandler<FilterPersonQuery, IEnumerable<PersonDetailsDto>>
    {
        private readonly IPersonRepository _personRepository;

        public FilterPersonQueryHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public async Task<IEnumerable<PersonDetailsDto>> Handle(FilterPersonQuery request, CancellationToken cancellationToken)
        {
            return (await _personRepository.FilterByAsync(request.FirstName, request.LastName))
                          .Select(x => new PersonDetailsDto()
                          {
                            Id=x.Id,
                            FirstName = x.FirstName,
                            LastName = x.LastName,
                            Email = x.Email,
                            UserName = x.UserName
                          });
        }
    }
}
