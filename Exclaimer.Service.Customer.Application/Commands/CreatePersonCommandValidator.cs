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
            RuleFor(command => command.FirstName)
                .NotEmpty().WithMessage("FirstName is required.");

            RuleFor(command => command.DateOfBirth)
                .NotEmpty().WithMessage("Date of birth is required.")
                .Must(BeAValidDate).WithMessage("Invalid date of birth.");
        }

        private bool BeAValidDate(DateTime? date)
        {
            // Add custom date validation logic here
            return date >= DateTime.Now.AddYears(-100) && date <= DateTime.Now;
        }
    }
}
