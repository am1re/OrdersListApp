using FluentValidation;

namespace Application.Orders.Commands.Delete
{
    public class DeleteOrderCommandValidator : AbstractValidator<DeleteOrderCommand>
    {
        public DeleteOrderCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}