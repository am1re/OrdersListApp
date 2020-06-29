using MediatR;

namespace Application.Products.Queries.GetList
{
    public class GetProductsListQuery : IRequest<ProductsListVm>
    {
        public int Offset { get; set; } = 0;
        public int Limit { get; set; } = 10;
    }
}