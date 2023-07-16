using Domain;

namespace Application.Contract.Person
{
    public interface IPersonRepository:IGeneralRepository<Domain.Person,string>
    {
         Task<Domain.Person?> GetPersonWithAddresses(string id);
         Task<IEnumerable<Domain.Person>> FilterByAsync(string? FirstName, string? LastName);
    }
}
