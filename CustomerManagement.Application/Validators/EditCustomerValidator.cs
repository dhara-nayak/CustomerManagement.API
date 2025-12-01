using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerManagement.Application.DTOs;
using FluentValidation;

namespace CustomerManagement.Application.Validators
{
    public class EditCustomerValidator : AbstractValidator<EditCustomerDto>
    {
        public EditCustomerValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.LastName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Phone).NotEmpty().MaximumLength(20);
            RuleFor(x => x.Address).NotEmpty().MaximumLength(100);
            RuleFor(x => x.DateOfBirth).LessThan(DateTime.Now);
        }

    }
}
