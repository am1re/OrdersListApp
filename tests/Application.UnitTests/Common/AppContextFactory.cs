using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.UnitTests.Common
{
    public static class AppContextFactory
    {
        public static AppDbContext Create()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new AppDbContext(options);
            
            context.Database.EnsureCreated();
            
            context.Products.AddRange(AppDbContextSeed.Products);
            context.Statuses.AddRange(AppDbContextSeed.Statuses);
            context.Orders.AddRange(AppDbContextSeed.Orders);
            context.OrderItems.AddRange(AppDbContextSeed.OrderItems);

            context.SaveChanges();
            return context;
        }

        public static void Destroy(AppDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}