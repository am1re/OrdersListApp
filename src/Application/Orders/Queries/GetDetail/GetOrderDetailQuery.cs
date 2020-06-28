using MediatR;

namespace Application.Orders.Queries.GetDetail
{
    public class GetOrderItemQuery : IRequest<OrderItemVm>
    {
        public int Id { get; set; }
    }
}