using FluentValidation;

namespace Application.Statuses.Commands.Update
{
    public class UpdateStatusCommandValidator : AbstractValidator<UpdateStatusCommand>
    {
        public UpdateStatusCommandValidator()
        {
            RuleFor(x => x.Name).Length(3, 100);
        }
    }
}