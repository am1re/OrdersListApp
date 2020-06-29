using FluentValidation;

namespace Application.Orders.Queries.GetDetail
{
    public class GetOrderItemQueryValidator : AbstractValidator<GetOrderDetailQuery>
    {
        public GetOrderItemQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}