using MediatR;

namespace Application.OrderItems.Queries.GetList
{
    public class GetOrderItemsListQuery : IRequest<OrderItemsListVm>
    {
        public int? OrderId { get; set; }
        public int Offset { get; set; } = 0;
        public int Limit { get; set; } = 10;
    }
}