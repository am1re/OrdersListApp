using System.Collections.Generic;
using MediatR;

namespace Application.Orders.Commands.Create
{
    public class CreateOrderCommand : IRequest<int>
    {
        public int StatusId { get; set; }
        public ICollection<OrderItemCreateModel> OrderItems { get; set; }
    }
}