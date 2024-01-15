using Exclaimer.Service.Customer.Application.Abstract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exclaimer.Service.Customer.Application.Commands
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomer, Domain.Entities.Customer>
    {
        private readonly ICustomerRepository _customerRepository;

        public CreateCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Domain.Entities.Customer> Handle(CreateCustomer request, CancellationToken cancellationToken)
        {
            var customer = new Domain.Entities.Customer
            {
                FirstName  = request.FirstName,
                LastName = request.LastName,
                Address = request.Address,
                City = request.City,
                Country = request.Country,
                DateOfBirth = request.DateOfBirth,  
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                PostalCode = request.PostalCode,                
            };

            return await _customerRepository.AddCustomer(customer);
        }
    }
}
