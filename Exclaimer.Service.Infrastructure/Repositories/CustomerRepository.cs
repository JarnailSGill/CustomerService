using Exclaimer.Service.Customer.Application.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exclaimer.Service.Customer.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDbContext _context;

        public CustomerRepository(CustomerDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Entities.Customer> AddCustomer(Domain.Entities.Customer toCreate)
        {
            _context.Customer.Add(toCreate);

            await _context.SaveChangesAsync();

            return toCreate;
        }

        public async Task DeleteCustomer(int customerId)
        {
            var customer = _context.Customer.FirstOrDefault(p => p.Id == customerId);

            if (customer is null) return;

            _context.Customer.Remove(customer);

            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Domain.Entities.Customer>> GetAll()
        {
            return await _context.Customer.ToListAsync();
        }

        //public async Task<Domain.Entities.Customer> GetCustomerById(int customerId)
        //{
        //    return await _context.Customer.SingleOrDefault(p => p.Id.Equals(customerId));
        //}

        //public async Task<Domain.Entities.Customer> UpdateCustomer(int customerId, string name, string email)
        //{
        //    var customer = await _context.Customer.SingleOrDefault(p => p.Id == customerId);
        //    customer.Name = name;
        //    customer.Email = email;

        //    await _context.SaveChangesAsync();

        //    return customer;
        //}
    }
}
