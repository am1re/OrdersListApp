using MediatR;

namespace Application.OrderItems.Queries.GetDetail
{
    public class GetOrderItemDetailQuery : IRequest<OrderItemDetailVm>
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
    }
}