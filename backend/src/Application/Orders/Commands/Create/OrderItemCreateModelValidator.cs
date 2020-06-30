using FluentValidation;

namespace Application.Orders.Commands.Create
{
    public class OrderItemCreateModelValidator : AbstractValidator<OrderItemCreateModel>
    {
        public OrderItemCreateModelValidator()
        {
            RuleFor(m => m.Quantity).GreaterThanOrEqualTo(0);
            RuleFor(m => m.ProductId).GreaterThan(0);
        }
    }
}