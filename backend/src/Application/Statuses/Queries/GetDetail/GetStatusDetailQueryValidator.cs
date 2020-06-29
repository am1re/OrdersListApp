using FluentValidation;

namespace Application.Statuses.Queries.GetDetail
{
    public class GetStatusDetailQueryValidator : AbstractValidator<GetStatusDetailQuery>
    {
        public GetStatusDetailQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}