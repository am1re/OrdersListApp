using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int StatusId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }

        public Status Status { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}