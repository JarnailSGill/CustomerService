using Microsoft.EntityFrameworkCore;

namespace Exclaimer.Service.Customer.Infrastructure
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Domain.Entities.Customer> Customer { get; set; }
    };
}
