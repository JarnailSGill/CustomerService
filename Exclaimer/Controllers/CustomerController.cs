using AutoMapper;
using Exclaimer.Service.Customer.Application.Commands;
using Exclaimer.Service.Customer.Application.DTOs;
using Exclaimer.Service.Customer.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Exclaimer.Service.Customer.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CustomerController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PersonDTO))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(IActionResult))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(IActionResult))]
        public async Task<IActionResult> Create([FromBody] PersonDTO request)
        {
            var person = _mapper.Map<Person>(request);
            var createCustomer = new CreatePersonCommand(person);
            var customer = await _mediator.Send(createCustomer);

            return Ok(customer);
        }

    }
}
