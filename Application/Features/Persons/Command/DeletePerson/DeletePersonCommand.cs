using MediatR;

namespace Application.Features.Persons.Command.DeletePerson
{
    public class DeletePersonCommand : IRequest<bool>
    {
        public string Id { get; set; }
    }
}
