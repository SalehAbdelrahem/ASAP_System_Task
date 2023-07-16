using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MyDBContext
{
    public class TaskDbContext : IdentityDbContext<Person>
    {

        public TaskDbContext(Microsoft.EntityFrameworkCore.DbContextOptions<TaskDbContext> options) : base(options)
        {
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Address> Addresses { get; set; }

    }
}