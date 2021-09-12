using FluentValidation;

namespace BasketCase.Application.Commands.AddProductToBasket
{
    public class AddProductToBasketCommandValidator : AbstractValidator<AddProductToBasketCommand>
    {
        public AddProductToBasketCommandValidator()
        {
            RuleFor(k => k.ProductId)
                .NotEmpty().WithMessage("ProductId can not be null.")
                .Length(24,24).WithMessage("ProductId not a object id.");

            RuleFor(k => k.Quantity)
                .NotEmpty().WithMessage("Quantity can not empty.")
                .GreaterThan(0).WithMessage("Quantity must greater than {0}.");

        }
    }
}