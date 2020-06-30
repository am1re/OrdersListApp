using MediatR;

namespace Application.OrderItems.Commands.Delete
{
    public class DeleteOrderItemCommand : IRequest
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
    }
}