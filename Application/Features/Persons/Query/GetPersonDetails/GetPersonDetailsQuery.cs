using DTOS.Person;
using MediatR;

namespace Application.Features.Persons.Query.GetPersonDetails

{
    public class GetPersonDetailsQuery : IRequest<PersonDetailsDto>
    {
        public string Id { get; set; }
    }
}
