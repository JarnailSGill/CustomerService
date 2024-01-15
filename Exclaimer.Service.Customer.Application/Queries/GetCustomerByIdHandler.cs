using Exclaimer.Service.Customer.Application.Abstract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exclaimer.Service.Customer.Application.Queries
{
    public class GetCustomerByIdHandler : IRequestHandler<GetCustomerById, Domain.Entities.Customer>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerByIdHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<Domain.Entities.Customer> Handle(GetCustomerById request, CancellationToken cancellationToken)
        {
            return await _customerRepository.GetCustomerById(request.Id);
        }
    }
}
