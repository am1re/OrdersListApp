using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Internal;

namespace Infrastructure
{
    public static class AppDbContextSeed
    {
        public static async Task SeedSampleDataAsync(AppDbContext context)
        {
            if (context.Products.Any() && 
                context.Statuses.Any() && 
                context.Orders.Any() &&
                context.OrderItems.Any()) return;

                var products = new List<Product>
                {
                    new Product { Name = "Product1", Price = 50.0m, PhotoUrl = "url" },
                    new Product { Name = "Product2", Price = 51.0m, PhotoUrl = "url" },
                    new Product { Name = "Product3", Price = 52.0m, PhotoUrl = "url" }
                };
                
                var statuses = new List<Status>
                {
                    new Status { Name = "Pending" },
                    new Status { Name = "Processing" },
                    new Status { Name = "On-hold" },
                    new Status { Name = "Completed" },
                    new Status { Name = "Completed" },
                    new Status { Name = "Cancelled" },
                    new Status { Name = "Refunded" },
                    new Status { Name = "Archive" }
                };
                
                var orders = new List<Order>
                {
                    new Order { DateCreated = DateTime.Now, Status = statuses[0] },
                    new Order { DateCreated = DateTime.Now.AddDays(-30), Status = statuses[3] }
                };
                
                var orderItems = new List<OrderItem>
                {
                    new OrderItem { Order = orders[0], Product = products[0], Quantity = 5, ProductPrice = products[0].Price },
                    new OrderItem { Order = orders[1], Product = products[1], Quantity = 7, ProductPrice = products[1].Price }
                };
                
                await context.Products.AddRangeAsync(products);
                await context.Statuses.AddRangeAsync(statuses);
                await context.Orders.AddRangeAsync(orders);
                await context.OrderItems.AddRangeAsync(orderItems);
                await context.SaveChangesAsync();
        }
    }
}