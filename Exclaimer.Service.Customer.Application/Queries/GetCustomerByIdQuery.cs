using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exclaimer.Service.Customer.Application.Queries
{
    public class GetCustomerByIdQuery : IRequest<Domain.Entities.Customer>
    {
        public int Id { get; set; }
    }
}
