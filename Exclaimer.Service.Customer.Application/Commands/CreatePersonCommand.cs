using Exclaimer.Service.Customer.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exclaimer.Service.Customer.Application.Commands
{
    public record CreatePersonCommand(Person Person) : IRequest<Person>
    {

    }
}
