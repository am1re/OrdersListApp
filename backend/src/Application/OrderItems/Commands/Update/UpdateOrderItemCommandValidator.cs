using FluentValidation;

namespace Application.OrderItems.Commands.Update
{
    public class UpdateOrderItemCommandValidator : AbstractValidator<UpdateOrderItemCommand>
    {
        public UpdateOrderItemCommandValidator()
        {
            RuleFor(x => x.OrderId).GreaterThan(0);
            RuleFor(x => x.ProductId).GreaterThan(0);
            RuleFor(x => x.Quantity).GreaterThanOrEqualTo(0);
        }
    }
}