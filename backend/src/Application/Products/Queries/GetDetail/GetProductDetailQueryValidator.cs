using FluentValidation;

namespace Application.Products.Queries.GetDetail
{
    public class GetProductDetailQueryValidator : AbstractValidator<GetProductDetailQuery>
    {
        public GetProductDetailQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}