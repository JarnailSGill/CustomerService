using Exclaimer.Service.Customer.Application.Commands;
using Exclaimer.Service.Customer.Application.DTOs;
using Exclaimer.Service.Customer.Domain.Entities;
using FluentValidation;
using FluentValidation.TestHelper;

namespace Exclaimer.Service.Customer.UnitTests
{
    public class CreatePersonCommandValidatorTests
    {
        private readonly CreatePersonCommandValidator _validator;

        public CreatePersonCommandValidatorTests()
        {
            _validator = new CreatePersonCommandValidator();
        }

        [Fact]
        public void ValidPersonRequest_Should_Return_IsValid_True()
        {
            var createValidPerson = CreateValidPersonRequest();

            var validationResult =  _validator.Validate(createValidPerson);

            Assert.True(validationResult.IsValid);
        }

        public static CreatePersonCommand CreateValidPersonRequest()
        {
            var person = new Person
            {
                FirstName = "John",
                LastName = "Smith",
                Email = "John.Smith@outlook.co.uk",
                PhoneNumber = "07450742011",
                Address = "24 High Street",
                City = "Birmingham",
                PostalCode = "B68 8LA",
                Country = "West Midlands",
                DateOfBirth = DateTime.UtcNow.AddYears(-30)
            };

            return new CreatePersonCommand(person);
        }

    }
}