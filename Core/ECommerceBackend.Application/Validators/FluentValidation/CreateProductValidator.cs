using ECommerceBackend.Application.ViewModels.Products;
using FluentValidation;

namespace ECommerceBackend.Application.Validators.FluentValidation
{
    public class CreateProductValidator : AbstractValidator<VM_Create_Product>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Product name is required!")
                .MaximumLength(150)
                .MinimumLength(3)
                    .WithMessage("The length of the product name must be between 5 and 150 characters.");

            RuleFor(p => p.Stock)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Stock info is required.")
                .Must(s => s >= 0)
                    .WithMessage("Stock info must be greater than zero.");

            RuleFor(p => p.Price)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Price info is required.")
                .Must(s => s >= 0)
                    .WithMessage("Price info must be greater than zero.");
        }
    }
}
