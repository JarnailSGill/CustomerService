using Exclaimer.Service.Customer.Application.Abstract;
using Exclaimer.Service.Customer.Domain.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exclaimer.Service.Customer.Application.Commands
{
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, Person>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IValidator<CreatePersonCommand> _validator;

        public CreatePersonCommandHandler(ICustomerRepository customerRepository, IValidator<CreatePersonCommand> validator)
        {
            _customerRepository = customerRepository;
            _validator = validator;
        }

        public async Task<Person> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var person = new Person
            {
                FirstName = request.Person.FirstName,
                LastName = request.Person.LastName,
                Address = request.Person.Address,
                City = request.Person.City,
                Country = request.Person.Country,
                DateOfBirth = request.Person.DateOfBirth,
                Email = request.Person.Email,
                PhoneNumber = request.Person.PhoneNumber,
                PostalCode = request.Person.PostalCode,
                RegistrationDate = DateTime.Now
            };

            return await _customerRepository.AddCustomer(person);
        }
    }
}
