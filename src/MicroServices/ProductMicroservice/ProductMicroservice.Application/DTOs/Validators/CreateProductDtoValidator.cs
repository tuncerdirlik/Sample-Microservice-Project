using FluentValidation;

namespace ProductMicroservice.Application.DTOs.Validators
{
    public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
    {
        public CreateProductDtoValidator()
        {
            RuleFor(k => k.Title)
                    .NotEmpty().WithMessage("{PropertyName} is required")
                    .MaximumLength(50).WithMessage("{PropertyName} must not be longer than 50");

            RuleFor(k => k.Description)
                    .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(k => k.Price)
                    .NotNull().WithMessage("{PropertyName} is required")
                    .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0");

            RuleFor(k => k.StockCount)
                    .NotNull().WithMessage("{PropertyName} is required")
                    .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0");
        }
    }
}
