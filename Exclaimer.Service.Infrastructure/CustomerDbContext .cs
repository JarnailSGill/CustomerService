using Microsoft.EntityFrameworkCore;

namespace Exclaimer.Service.Customer.Infrastructure
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {
        }

        public DbSet<Domain.Entities.Customer> Customer { get; set; }
    };
}
