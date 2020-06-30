using FluentValidation;

namespace Application.Products.Commands.Update
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.Name).Length(3, 100);
            RuleFor(x => x.Price).GreaterThanOrEqualTo(0);
            RuleFor(x => x.PhotoUrl).MaximumLength(100);
        }
    }
}