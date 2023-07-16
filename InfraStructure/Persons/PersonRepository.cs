using Application.Contract.Person;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyDBContext;
using System.Diagnostics.Metrics;

namespace Infrastructre.Persons
{
    public class PersonRepository : GeneralRepository<Person, string>, IPersonRepository
    {
       
        public PersonRepository(TaskDbContext context) : base(context)
        {
        }

        public Task<IEnumerable<Person>> FilterByAsync(string? FirstName, string? LastName)
        {
            IEnumerable<Person> FilterPersonQuery =
               _context.Persons.Include(x => x.Addresses)
               .Where(a => FirstName == null || a.FirstName.ToLower().Contains(FirstName.ToLower()))
               .Where(a => LastName == null || a.LastName.ToLower().Contains(LastName.ToLower()));
              

            return Task.FromResult(FilterPersonQuery);
        }

        public async Task<Person?> GetPersonWithAddresses(string id)
        {
            return await _context.Persons.Include(a=>a.Addresses).FirstOrDefaultAsync(x=> x.Id == id);  
        }
    }
}
