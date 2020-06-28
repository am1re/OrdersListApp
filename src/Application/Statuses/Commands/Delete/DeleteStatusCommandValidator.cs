using FluentValidation;

namespace Application.Statuses.Commands.Delete
{
    public class DeleteStatusCommandValidator : AbstractValidator<DeleteStatusCommand>
    {
        public DeleteStatusCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}