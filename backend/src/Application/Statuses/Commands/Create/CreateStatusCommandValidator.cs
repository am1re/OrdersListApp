using FluentValidation;

namespace Application.Statuses.Commands.Create
{
    public class CreateStatusCommandValidator : AbstractValidator<CreateStatusCommand>
    {
        public CreateStatusCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().Length(3, 100);
        }
    }
}