using FluentValidation;

namespace Application.Products.Queries.GetList
{
    public class GetProductsListQueryValidator : AbstractValidator<GetProductsListQuery>
    {
        public GetProductsListQueryValidator()
        {
            RuleFor(x => x.Offset).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Limit).GreaterThanOrEqualTo(0);
        }
    }
}