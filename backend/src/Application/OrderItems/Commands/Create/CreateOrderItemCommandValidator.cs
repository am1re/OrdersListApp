using FluentValidation;

namespace Application.OrderItems.Commands.Create
{
    public class CreateOrderItemCommandValidator : AbstractValidator<CreateOrderItemCommand>
    {
        public CreateOrderItemCommandValidator()
        {
            RuleFor(x => x.OrderId).GreaterThan(0);
            RuleFor(x => x.ProductId).GreaterThan(0);
            RuleFor(x => x.Quantity).GreaterThanOrEqualTo(0);
        }
    }
}