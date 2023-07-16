using Application.Contract.Address;
using MediatR;

namespace Application.Features.Addesses.Commands.DeleteAddress
{
    public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand, bool>
    {
        private readonly IAddressRepository _addressRepository;

        public DeleteAddressCommandHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public async Task<bool> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            return await _addressRepository.DeleteAsync(request.Id);

        }
    }
}
