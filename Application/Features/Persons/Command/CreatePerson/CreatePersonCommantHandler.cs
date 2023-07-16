using Application.Contract.Person;
using Application.Contracts.User;
using Application.Features.Persons.Command.CreatePerson;
using Domain;
using Dtos.Users;
using DTOS.Person;
using MediatR;

namespace Application.Features.Persons.Command.CreatePerson
{
    internal class CreatePersonCommantHandler : IRequestHandler<CreatePersonCommant, PersonMinimalDto>
    {
        private readonly IPersonAccountRepository _personAccountRepository;

        public CreatePersonCommantHandler(IPersonAccountRepository personAccountRepository)
        {
         _personAccountRepository=personAccountRepository;
        }

        public async Task<PersonMinimalDto> Handle(CreatePersonCommant request, CancellationToken cancellationToken)
        {
            RegistrationModel registrationModel = new RegistrationModel()
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Password = request.PassWord,
                UserName=request.UserName 
            };
            var result = await _personAccountRepository.Registration(registrationModel);
            if (result.IsAuthenticated)
            {
                return new PersonMinimalDto {

                    FirstName =request.FirstName,
                    LastName = request.LastName,
                    UserName = request.UserName,
                    Email = request.Email
                    };
            }
            else { throw new Exception(result.Message); }
        }
    }
}
