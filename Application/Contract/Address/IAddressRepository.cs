using Domain;
using DTOS.Address;

namespace Application.Contract.Address

{
    public interface IAddressRepository : IGeneralRepository<Domain.Address, int>
    {
        // Task <Domain.Person?> GetAddressesWithPersonIdAsync(string userid);
        Task<IEnumerable<Domain.Address>?> GetAddressesWithPersonIdAsync(string userid);
        Task<IEnumerable<Domain.Address>> FilterByAsync(string ? Address1, string? Address2, string? City ,string? Country);
        

    }
}
