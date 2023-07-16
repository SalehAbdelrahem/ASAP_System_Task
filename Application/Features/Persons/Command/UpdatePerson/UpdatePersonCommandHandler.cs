using Application.Contract.Address;
using Application.Contract.Person;
using Domain;
using MediatR;

namespace Application.Features.Persons.Command.UpdatePerson

{
    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand, bool>
    {
        private readonly IPersonRepository _personRepository;

        public UpdatePersonCommandHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<bool> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var user = await _personRepository.GetDetailsAsync(request.Id);
            if (user is null) { 
                return false;
            }
            else
            {
                if (request.FirstName != null)
                    user.FirstName = request.FirstName;
                if (request.FirstName != null)
                    user.LastName = request.LasttName;
                
                return await _personRepository.UpdateAsync(user);
            }
        }
    }
}
