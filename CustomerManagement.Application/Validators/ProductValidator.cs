using CustomerManagement.Application.DTOs;
using FluentValidation;

namespace CustomerManagement.Application.Validators
{
    public class ProductValidator : AbstractValidator<ProductSaveDto>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithName("Product name is Required")
                .MinimumLength(3).WithMessage("Product name must be at least 3 characters long")
                .MaximumLength(50).WithMessage("Product name must not exceed 50 characters ");

            RuleFor(p => p.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0");
        }

        public class ProductSaveValidator : AbstractValidator<ProductSaveDto>
        {
            public ProductSaveValidator()
            {
                RuleFor(p => p.Name)
                    .NotEmpty().WithName("Product name is Required")
                    .MinimumLength(3).WithMessage("Product name must be at least 3 characters long")
                     .MaximumLength(50).WithMessage("Product name must not exceed 50 characters ");

                RuleFor(p => p.Price)
                    .GreaterThan(0).WithMessage("Price must be greater than 0");
            }
        }

    }
}
