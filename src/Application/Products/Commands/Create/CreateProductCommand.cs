using MediatR;

namespace Application.Products.Commands.Create
{
    public class CreateProductCommand : IRequest<int>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string PhotoUrl { get; set; }
    }
}