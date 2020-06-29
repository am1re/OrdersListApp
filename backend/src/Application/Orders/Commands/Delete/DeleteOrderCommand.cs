using MediatR;

namespace Application.Orders.Commands.Delete
{
    public class DeleteOrderCommand : IRequest
    {
        public int Id { get; set; }
    }
}