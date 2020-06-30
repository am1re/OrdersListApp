using FluentValidation;

namespace Application.Products.Commands.Delete
{
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}