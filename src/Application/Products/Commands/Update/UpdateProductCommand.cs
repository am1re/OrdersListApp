using MediatR;

namespace Application.Products.Commands.Update
{
    public class UpdateProductCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string PhotoUrl { get; set; }
    }
}