using FluentValidation;

namespace Application.Statuses.Queries.GetList
{
    public class GetStatusesListQueryValidator : AbstractValidator<GetStatusesListQuery>
    {
        public GetStatusesListQueryValidator()
        {
            RuleFor(x => x.Offset).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Limit).GreaterThanOrEqualTo(0);
        }
    }
}