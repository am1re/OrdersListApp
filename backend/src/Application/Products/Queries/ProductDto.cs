using Application.Common.Mapping;
using Domain.Entities;

namespace Application.Products.Queries
{
    public class ProductDto : IMapFrom<Product>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string PhotoUrl { get; set; }
    }
}