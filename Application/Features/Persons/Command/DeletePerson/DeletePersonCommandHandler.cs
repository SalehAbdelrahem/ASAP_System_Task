using Application.Contract.Address;
using Application.Contract.Person;
using MediatR;

namespace Application.Features.Persons.Command.DeletePerson
{
    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand, bool>
    {
        private readonly IPersonRepository _personRepository;

        public DeletePersonCommandHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public async Task<bool> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            return await _personRepository.DeleteAsync(request.Id);
        }
    }
}
