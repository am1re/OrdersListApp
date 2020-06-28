using MediatR;

namespace Application.OrderItems.Commands.Create
{
    public class CreateOrderItemCommand : IRequest<(int orderId, int productId)>
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}