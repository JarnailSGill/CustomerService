using Exclaimer.Service.Customer.Application.Commands;
using Exclaimer.Service.Customer.Web.DTOs;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Exclaimer.Service.Customer.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(CustomerDTO))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(IActionResult))]
        public async Task<IActionResult> Create([FromBody] CustomerDTO request)
        {
            var createCustomer = new CreateCustomerCommand { FirstName = request.FirstName };
            var customer = await _mediator.Send(createCustomer);

            return Ok(customer);
        }

    }
}
