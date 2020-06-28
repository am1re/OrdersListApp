using FluentValidation;

namespace Application.Orders.Commands.Update
{
    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator()
        {
            RuleFor(o => o.Id).GreaterThan(0);
            RuleFor(o => o.StatusId).GreaterThan(0);
        }
    }
}