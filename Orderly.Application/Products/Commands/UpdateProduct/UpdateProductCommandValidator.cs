using FluentValidation;
using FluentValidation.Validators;

namespace Orderly.Application.Products.Commands.UpdateProduct;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(dto => dto.Name)
            .NotEmpty()
            .Length(2, 100);

        RuleFor(dto => dto.Description)
            .Length(0, 250);

        RuleFor(dto => dto.Price)
            .GreaterThanOrEqualTo(0.0m).WithMessage("Price should be greater than or equal to zero")
            .PrecisionScale(18, 2, true).WithMessage("The value must have up to 18 digits in total, with 2 digits after the decimal point, ignoring trailing zeros.");
    }

}
