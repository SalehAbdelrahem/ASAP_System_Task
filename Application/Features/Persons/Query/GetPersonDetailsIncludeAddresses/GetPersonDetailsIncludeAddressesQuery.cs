using DTOS.Person;
using MediatR;

namespace Application.Features.Departments.Query.GetDepartmentDetailsIncludeEmployess
{
    public class GetPersonDetailsIncludeAddressesQuery : IRequest<PersonDetailsWithAddressesDto>
    {
        public string Id { get; set; }
    }
}
