using FluentValidation;

namespace Application.OrderItems.Queries.GetList
{
    public class GetOrderItemsListQueryValidator : AbstractValidator<GetOrderItemsListQuery>
    {
        public GetOrderItemsListQueryValidator()
        {
            RuleFor(x => x.OrderId).GreaterThan(0);
            RuleFor(x => x.Offset).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Limit).GreaterThanOrEqualTo(0);
        }
    }
}