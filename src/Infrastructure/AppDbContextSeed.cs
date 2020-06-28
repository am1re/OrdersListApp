using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
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
                context.OrderDetails.Any()) return;

                var products = new List<Product>
                {
                    new Product { Name = "Product1", Price = 50.0m, PhotoUrl = "url" },
                    new Product { Name = "Product2", Price = 51.0m, PhotoUrl = "url" },
                    new Product { Name = "Product3", Price = 52.0m, PhotoUrl = "url" }
                };
                
                var statuses = new List<Status>
                {
                    new Status { Name = "Awaiting confirmation" },
                    new Status { Name = "Confirmed" },
                    new Status { Name = "Closed" },
                    new Status { Name = "Cancelled" }
                };
                
                var orders = new List<Order>
                {
                    new Order { DateCreated = DateTime.Now, Status = statuses[0] },
                    new Order { DateCreated = DateTime.Now.AddDays(-30), Status = statuses[3] }
                };
                
                var orderDetails = new List<OrderDetail>
                {
                    new OrderDetail { Order = orders[0], Product = products[0], Quantity = 5, ProductPrice = products[0].Price },
                    new OrderDetail { Order = orders[1], Product = products[1], Quantity = 7, ProductPrice = products[1].Price }
                };
                
                await context.Products.AddRangeAsync(products);
                await context.Statuses.AddRangeAsync(statuses);
                await context.Orders.AddRangeAsync(orders);
                await context.OrderDetails.AddRangeAsync(orderDetails);
                await context.SaveChangesAsync();
        }
    }
}