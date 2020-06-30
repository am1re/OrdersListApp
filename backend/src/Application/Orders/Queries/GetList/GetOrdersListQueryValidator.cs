using FluentValidation;

namespace Application.Orders.Queries.GetList
{
    public class GetOrdersListQueryValidator : AbstractValidator<GetOrdersListQuery>
    {
        public GetOrdersListQueryValidator()
        {
            RuleFor(x => x.Offset).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Limit).GreaterThanOrEqualTo(0);
        }
    }
}