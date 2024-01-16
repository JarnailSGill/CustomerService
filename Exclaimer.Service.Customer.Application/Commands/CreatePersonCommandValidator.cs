using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exclaimer.Service.Customer.Application.Commands
{
    public class CreatePersonCommandValidator : AbstractValidator<CreatePersonCommand>
    {
        public CreatePersonCommandValidator()
        {
            RuleFor(command => command.Person.FirstName)
                .NotEmpty().WithMessage("First Name is required.")
                .MaximumLength(50).WithMessage("First Name cannot exceed 50 characters.");

            RuleFor(command => command.Person.LastName)
                .NotEmpty().WithMessage("Last Name is required.")
                .MaximumLength(50).WithMessage("Last Name cannot exceed 50 characters.");

            RuleFor(command => command.Person.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.")
                .MaximumLength(100).WithMessage("Email cannot exceed 100 characters.");

            RuleFor(command => command.Person.PhoneNumber)
                .NotEmpty().WithMessage("Phone Number is required.")
                .MaximumLength(20).WithMessage("Phone Number cannot exceed 20 characters.");

            RuleFor(command => command.Person.Address)
                .NotEmpty().WithMessage("Address is required.")
                .MaximumLength(100).WithMessage("Address cannot exceed 100 characters.");

            RuleFor(command => command.Person.City)
                .NotEmpty().WithMessage("City is required.")
                .MaximumLength(50).WithMessage("City cannot exceed 50 characters.");

            RuleFor(command => command.Person.PostalCode)
                .NotEmpty().WithMessage("Postal Code is required.")
                .MaximumLength(20).WithMessage("Postal Code cannot exceed 20 characters.");

            RuleFor(command => command.Person.Country)
                .NotEmpty().WithMessage("Country is required.")
                .MaximumLength(50).WithMessage("Country cannot exceed 50 characters.");

            RuleFor(command => command.Person.DateOfBirth)
                .NotEmpty().WithMessage("Date of Birth is required.")
                .Must(BeAValidDate).WithMessage("Invalid Date of Birth.");
        }

        private bool BeAValidDate(DateTime? date)
        {
            return date >= DateTime.Now.AddYears(-100) && date <= DateTime.Now.AddYears(-1);
        }
    }
}
