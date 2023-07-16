using DTOS.Person;
using MediatR;

namespace Application.Features.Persons.Query.FilterPerson
{
    public class FilterPersonQuery:IRequest<IEnumerable<PersonDetailsDto>>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
