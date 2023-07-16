using DTOS.Person;
using MediatR;

namespace Application.Features.Persons.Query.GetAllPerson
{
    public class GetAllPersonQuery : IRequest<IEnumerable<PersonMinimalDto>>
    {
    }
}
