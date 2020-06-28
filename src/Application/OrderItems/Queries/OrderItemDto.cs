using Application.Common.Mapping;
using Domain.Entities;

namespace Application.OrderItems.Queries
{
    public class OrderItemDto : IMapFrom<OrderItem>
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
    }
}