using MediatR;

namespace Application.Products.Commands.Delete
{
    public class DeleteProductCommand : IRequest
    {
        public int Id { get; set; }
    }
}