using Exclaimer.Service.Customer.Application.Commands;
using Exclaimer.Service.Customer.Application.DTOs;
using Exclaimer.Service.Customer.Domain.Entities;
using FluentValidation;
using FluentValidation.TestHelper;
using Xunit;

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
        public async Task ValidPersonRequest_Should_Return_IsValid_True()
        {
            var createValidPerson = CreateValidPersonRequest();

            var validationResult =  await _validator.ValidateAsync(createValidPerson);

            Assert.True(validationResult.IsValid);
        }

        [Theory]
        [InlineData("", "First Name is required.")]
        [InlineData("TestingAVeryVeryVeryVeryVeryVeryVeryVeryLongFirstName", "First Name cannot exceed 50 characters.")]
        public async Task InValidFirstName_Should_Return_IsValid_False_And_Error(string property, string errorMessage)
        {
            var createValidPerson = CreateValidPersonRequest();
            createValidPerson.Person.FirstName = property;

            var validationResult = await _validator.ValidateAsync(createValidPerson);

            Assert.False(validationResult.IsValid);
            Assert.Equal(validationResult.Errors?.SingleOrDefault()?.ErrorMessage, errorMessage);
        }

        [Theory]
        [InlineData("", "Email is required.")]
        [InlineData("invalid-email", "Invalid email format.")]
        [InlineData("a@b.com", null)]
        public async Task InValidEmail_Should_Return_IsValid_False_And_Error(string property, string errorMessage)
        {
            var createValidPerson = CreateValidPersonRequest();
            createValidPerson.Person.Email = property;

            var validationResult = await _validator.ValidateAsync(createValidPerson);

            if (string.IsNullOrEmpty(errorMessage))
            {
                Assert.True(validationResult.IsValid);
            }
            else
            {
                Assert.False(validationResult.IsValid);
                Assert.Equal(validationResult.Errors[0].ErrorMessage, errorMessage);
            }
        }

        [Theory]
        [InlineData("", "Phone Number is required.")]
        [InlineData("123456789012345678901", "Phone Number cannot exceed 20 characters.")]
        public async Task InValidPhoneNumber_Should_Return_IsValid_False_And_Error(string property, string errorMessage)
        {
            var createValidPerson = CreateValidPersonRequest();
            createValidPerson.Person.PhoneNumber = property;

            var validationResult = await _validator.ValidateAsync(createValidPerson);

            Assert.False(validationResult.IsValid);
            Assert.Equal(validationResult.Errors?.SingleOrDefault()?.ErrorMessage, errorMessage);
        }

        [Theory]
        [InlineData(null, "Date of Birth is required.")]
        [InlineData("2023-12-15", "Invalid Date of Birth.")]
        [InlineData("1922-01-15", "Invalid Date of Birth.")]
        public async Task InValidDateOfBirth_Should_Return_IsValid_False_And_Error(string dateOfBirth, string errorMessage)
        {
            var createValidPerson = CreateValidPersonRequest();
            createValidPerson.Person.DateOfBirth = dateOfBirth != null ? DateTime.Parse(dateOfBirth) : null;

            var validationResult = await _validator.ValidateAsync(createValidPerson);

            Assert.False(validationResult.IsValid);
            Assert.Equal(validationResult.Errors[0].ErrorMessage, errorMessage);
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