using System;
using System.Collections.Generic;
using Application.Common.Mapping;
using Application.OrderItems.Queries;
using Application.Statuses.Queries;
using Domain.Entities;

namespace Application.Orders.Queries
{
    public class OrderDto : IMapFrom<Order>
    {
        public int Id { get; set; }
        public StatusDto Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public ICollection<OrderItemDto> OrderItems { get; set; }
    }
}