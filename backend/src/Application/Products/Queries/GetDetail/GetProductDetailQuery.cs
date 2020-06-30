using MediatR;

namespace Application.Products.Queries.GetDetail
{
    public class GetProductDetailQuery : IRequest<ProductDetailVm>
    {
        public int Id { get; set; }
    }
}