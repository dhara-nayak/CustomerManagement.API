using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerManagement.Application.DTOs;
using FluentValidation;

namespace CustomerManagement.Application.Validators
{
    public class AddCustomerDtoValidator : AbstractValidator<AddCustomerDto>
    {
        public AddCustomerDtoValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required")
                .MaximumLength(20).WithMessage("First name cannot exceed 20 characters");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required")
                .MaximumLength(200).WithMessage("Last name cannot exceed 20 characters");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid Email Format")
                .Matches(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")
                .MaximumLength(50).WithMessage("Email Cannot excced 50 charachters");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Phone number is required")
                 .Matches(@"^\d{10,15}$")
                .MaximumLength(10).WithMessage("Phone number must be 10 digits");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address is Required")
                .MaximumLength(50).WithMessage("Address Cannot excced 50 charachters");

            RuleFor(x => x.DateOfBirth)
                .LessThan(DateTime.Now).WithMessage("Date of Birth must be in the Past.")
                .Must(BeAtLeast18).WithMessage("Customer must be Atleast 18 years old.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is Required")
                .MinimumLength(6).WithMessage("Password must be at least 6 charachters long ");
        }

     private bool BeAtLeast18(DateTime dob)
        {
            var today = DateTime.Today;
            var age = today.Year - dob.Year;
            if (dob.Date > today.AddYears(-age)) age--;
            return age >= 18;
        }
    }
}

//Validation logic in Application layer -- keeps business rules central and testable.