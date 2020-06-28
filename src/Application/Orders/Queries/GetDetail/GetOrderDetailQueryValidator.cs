using FluentValidation;

namespace Application.Orders.Queries.GetDetail
{
    public class GetOrderItemQueryValidator : AbstractValidator<GetOrderItemQuery>
    {
        public GetOrderItemQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}