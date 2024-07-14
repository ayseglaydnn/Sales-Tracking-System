using FluentValidation;

namespace Application.Features.Sales.Commands.Create;

public class CreateSaleCommandValidator : AbstractValidator<CreateSaleCommand>
{
    public CreateSaleCommandValidator()
    {
        RuleFor(c => c.CustomerId).NotEmpty();
        RuleFor(c => c.ProductId).NotEmpty();
        RuleFor(c => c.Quantity).NotEmpty();
        RuleFor(c => c.TotalAmount).NotEmpty();
        RuleFor(c => c.SaleDate).NotEmpty();
        RuleFor(c => c.Product).NotEmpty();
        RuleFor(c => c.Customer).NotEmpty();
    }
}