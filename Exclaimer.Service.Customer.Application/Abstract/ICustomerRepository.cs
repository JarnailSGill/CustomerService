using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exclaimer.Service.Customer.Application.Abstract
{
    public interface ICustomerRepository
    {
        Task<ICollection<Domain.Entities.Customer>> GetAll();

        Task<Domain.Entities.Customer> AddCustomer(Domain.Entities.Customer toCreate);

        Task DeleteCustomer(int customerId);

        //Task<Domain.Entities.Customer> UpdateCustomer(int customerId, string name, string email);

        Task<Domain.Entities.Customer> GetCustomerById(int customerId);

    }
}
