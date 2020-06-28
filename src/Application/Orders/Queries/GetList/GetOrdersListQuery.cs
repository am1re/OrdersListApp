using MediatR;

namespace Application.Orders.Queries.GetList
{
    public class GetOrdersListQuery : IRequest<OrdersListVm>
    {
        public int Offset { get; set; } = 0;
        public int Limit { get; set; } = 10;
    }
}