using FluentValidation;

namespace Application.Orders.Commands.Create
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(o => o.StatusId).GreaterThan(0);
            RuleForEach(o => o.OrderItems).SetValidator(new OrderItemCreateModelValidator());
        }
    }
}