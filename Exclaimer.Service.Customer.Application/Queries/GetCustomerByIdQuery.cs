using Exclaimer.Service.Customer.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exclaimer.Service.Customer.Application.Queries
{
    public record GetCustomerByIdQuery : IRequest<Person>
    {
        public int Id { get; set; }
    }
}
