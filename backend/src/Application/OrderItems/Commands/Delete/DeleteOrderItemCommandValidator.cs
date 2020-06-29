using FluentValidation;

namespace Application.OrderItems.Commands.Delete
{
    public class DeleteOrderItemCommandValidator : AbstractValidator<DeleteOrderItemCommand>
    {
        public DeleteOrderItemCommandValidator()
        {
            RuleFor(x => x.OrderId).GreaterThan(0);
            RuleFor(x => x.ProductId).GreaterThan(0);
        }
    }
}