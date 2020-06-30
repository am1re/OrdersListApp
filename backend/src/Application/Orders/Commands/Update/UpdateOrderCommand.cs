using MediatR;

namespace Application.Orders.Commands.Update
{
    public class UpdateOrderCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int StatusId { get; set; }
    }
}