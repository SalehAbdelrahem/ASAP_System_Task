using Application.Contract.Address;
using Domain;
using Microsoft.EntityFrameworkCore;
using MyDBContext;

namespace Infrastructre.Addresses
{
    public class AddressRepository : GeneralRepository<Address, int>, IAddressRepository
    {


        public AddressRepository(TaskDbContext context) : base(context)
        {

        }

        public Task<IEnumerable<Address>> FilterByAsync(string? Address1, string? Address2, string? City, string? Country)
        {
            IEnumerable<Address> FilterAddressQuery =
                _context.Addresses.Include(x => x.Person)
                .Where(a => Address1 == null || a.Address1.ToLower().Contains(Address1.ToLower()))
                .Where(a => Address2 == null || a.Address2.ToLower().Contains(Address2.ToLower()))
                .Where(a => City == null || a.City.ToLower().Contains(City.ToLower()))
                .Where(a => Country == null || a.Country.ToLower().Contains(Country.ToLower()));
              
            return Task.FromResult(FilterAddressQuery);
        }

        public async Task<IEnumerable<Address>?> GetAddressesWithPersonIdAsync(string userid)
        {
            var user = await _context.Persons.Include(a => a.Addresses).FirstOrDefaultAsync(x => x.Id == userid);
            if (user is not null)
            {
                List<Address> addresses = new List<Address>();
                foreach (var item in user.Addresses)
                {

                    addresses.Add(item);

                }
                return addresses;
            }
            else
                throw new Exception("not Found User");
        }
    }
}
