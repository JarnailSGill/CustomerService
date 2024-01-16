using Exclaimer.Service.Customer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exclaimer.Service.Customer.Application.Abstract
{
    public interface ICustomerRepository
    {
        Task<ICollection<Person>> GetAll();

        Task<Person> AddCustomer(Person toCreate);

        Task DeleteCustomer(int customerId);

        Task<Person> UpdateCustomer(int customerId, string name, string email);

        Task<Person> GetCustomerById(int customerId);

    }
}
