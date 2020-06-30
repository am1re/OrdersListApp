using MediatR;

namespace Application.Orders.Queries.GetDetail
{
    public class GetOrderDetailQuery : IRequest<OrderDetailVm>
    {
        public int Id { get; set; }
    }
}