using Exclaimer.Service.Customer.Application.Abstract;
using Exclaimer.Service.Customer.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exclaimer.Service.Customer.Application.Queries
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Person>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerByIdQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<Person> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            return await _customerRepository.GetCustomerById(request.Id);
        }
    }
}
