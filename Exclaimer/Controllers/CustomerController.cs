using AutoMapper;
using Exclaimer.Service.Customer.Application.Commands;
using Exclaimer.Service.Customer.Application.DTOs;
using Exclaimer.Service.Customer.Application.Queries;
using Exclaimer.Service.Customer.Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
            try
            {
                var person = _mapper.Map<Person>(request);
                var createCustomer = new CreatePersonCommand(person);
                var customer = await _mediator.Send(createCustomer);
                return Ok(customer.Id);
            }
            catch (ValidationException ex)
            {
                var errors = ex.Errors.Select(error => new
                {
                    Field = error.PropertyName,
                    Message = error.ErrorMessage
                }).ToList();

                return BadRequest(new { Errors = errors });
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(PersonResponseDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(IActionResult))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(IActionResult))]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid voucher ID.");

            var getCustomer = new GetCustomerByIdQuery { Id = id };
            var customer = await _mediator.Send(getCustomer);

            if (customer == null)
            {
                return NotFound($"Customer with Id {id} not found" );
            }

            return Ok(customer);
        }

    }
}
