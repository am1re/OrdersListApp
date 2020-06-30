using FluentValidation;

namespace Application.OrderItems.Queries.GetDetail
{
    public class GetOrderItemDetailQueryValidator : AbstractValidator<GetOrderItemDetailQuery>
    {
        public GetOrderItemDetailQueryValidator()
        {
            RuleFor(x => x.OrderId).GreaterThan(0);
            RuleFor(x => x.ProductId).GreaterThan(0);
        }
    }
}