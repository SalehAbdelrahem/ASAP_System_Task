using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Features.Persons.Command.UpdatePerson
{
    public class UpdatePersonCommand:IRequest<bool>
    {
        public string Id { get; set; }
        [MinLength(3),MaxLength(100)]
        public string? FirstName { get; set; }
        public string? LasttName { get; set; }
    }
}
