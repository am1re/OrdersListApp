using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure
{
    public class AppDbContextSeed
    {
        public static readonly List<Product> Products;
        public static readonly List<Status> Statuses;
        public static readonly List<Order> Orders;
        public static readonly List<OrderItem> OrderItems;

        static AppDbContextSeed()
        {
            Products = new List<Product>
            {
                new Product {Name="Soap - Mr.clean Floor Soap",Price=101.33m, PhotoUrl="http://dummyimage.com/250x250.png/cc0000/ffffff"},
                new Product {Name="Food Colouring - Pink",Price=158.25m, PhotoUrl="http://dummyimage.com/250x250.png/dddddd/000000"},
                new Product {Name="Turkey - Ground. Lean",Price=101.8m, PhotoUrl="http://dummyimage.com/250x250.png/ff4444/ffffff"},
                new Product {Name="Tumeric",Price=105.49m, PhotoUrl="http://dummyimage.com/250x250.png/5fa2dd/ffffff"},
                new Product {Name="Water - San Pellegrino",Price=125.07m, PhotoUrl="http://dummyimage.com/250x250.png/ff4444/ffffff"},
                new Product {Name="Truffle Shells - Semi - Sweet",Price=225.58m, PhotoUrl="http://dummyimage.com/250x250.png/ff4444/ffffff"},
                new Product {Name="Beer - Upper Canada Light",Price=186.1m, PhotoUrl="http://dummyimage.com/250x250.png/ff4444/ffffff"},
                new Product {Name="Mix - Cocktail Ice Cream",Price=217.6m, PhotoUrl="http://dummyimage.com/250x250.png/dddddd/000000"},
                new Product {Name="Jello - Assorted",Price=298.86m, PhotoUrl="http://dummyimage.com/250x250.png/ff4444/ffffff"},
                new Product {Name="Sultanas",Price=123.39m, PhotoUrl="http://dummyimage.com/250x250.png/ff4444/ffffff"},
                new Product {Name="Yucca",Price=109.18m, PhotoUrl="http://dummyimage.com/250x250.png/5fa2dd/ffffff"},
                new Product {Name="Garbage Bags - Black",Price=126.42m, PhotoUrl="http://dummyimage.com/250x250.png/ff4444/ffffff"},
                new Product {Name="Spaghetti Squash",Price=101.31m, PhotoUrl="http://dummyimage.com/250x250.png/dddddd/000000"},
                new Product {Name="Bread - Malt",Price=113.62m, PhotoUrl="http://dummyimage.com/250x250.png/cc0000/ffffff"},
                new Product {Name="Bread - Dark Rye",Price=281.88m, PhotoUrl="http://dummyimage.com/250x250.png/dddddd/000000"},
                new Product {Name="Cabbage - Savoy",Price=126.12m, PhotoUrl="http://dummyimage.com/250x250.png/5fa2dd/ffffff"},
                new Product {Name="Remy Red",Price=247.63m, PhotoUrl="http://dummyimage.com/250x250.png/dddddd/000000"},
                new Product {Name="Loquat",Price=99.08m, PhotoUrl="http://dummyimage.com/250x250.png/dddddd/000000"},
                new Product {Name="Sugar - Invert",Price=226.1m, PhotoUrl="http://dummyimage.com/250x250.png/cc0000/ffffff"},
                new Product {Name="Bread - Roll, Soft White Round",Price=163.17m, PhotoUrl="http://dummyimage.com/250x250.png/cc0000/ffffff"},
                new Product {Name="Yoplait - Strawbrasp Peac",Price=179.92m, PhotoUrl="http://dummyimage.com/250x250.png/cc0000/ffffff"},
                new Product {Name="Beans - Black Bean, Preserved",Price=37.22m, PhotoUrl="http://dummyimage.com/250x250.png/cc0000/ffffff"},
                new Product {Name="Sprouts - Pea",Price=34.5m, PhotoUrl="http://dummyimage.com/250x250.png/dddddd/000000"},
                new Product {Name="Foil - Round Foil",Price=118.45m, PhotoUrl="http://dummyimage.com/250x250.png/cc0000/ffffff"},
                new Product {Name="Lettuce - Radicchio",Price=67.5m, PhotoUrl="http://dummyimage.com/250x250.png/5fa2dd/ffffff"},
                new Product {Name="Pears - Fiorelle",Price=82.36m, PhotoUrl="http://dummyimage.com/250x250.png/dddddd/000000"}
            };

            Statuses = new List<Status>
            {
                new Status { Name = "Pending" },
                new Status { Name = "Processing" },
                new Status { Name = "On-hold" },
                new Status { Name = "Completed" },
                new Status { Name = "Cancelled" },
                new Status { Name = "Refunded" },
                new Status { Name = "Archive" }
            };

            Orders = new List<Order>
            {
                new Order {DateCreated = DateTime.Parse("2020-06-03T12:45:16Z"),Status = Statuses[2], DateModified = null},
                new Order {DateCreated = DateTime.Parse("2020-04-18T20:44:21Z"),Status = Statuses[4], DateModified = null},
                new Order {DateCreated = DateTime.Parse("2020-03-18T09:31:34Z"),Status = Statuses[6], DateModified = DateTime.Parse("2020-04-27T12:26:29Z")},
                new Order {DateCreated = DateTime.Parse("2019-10-25T07:03:05Z"),Status = Statuses[5], DateModified = null},
                new Order {DateCreated = DateTime.Parse("2020-05-18T23:30:44Z"),Status = Statuses[0], DateModified = null},
                new Order {DateCreated = DateTime.Parse("2019-08-08T08:48:40Z"),Status = Statuses[5], DateModified = null},
                new Order {DateCreated = DateTime.Parse("2020-03-08T21:16:41Z"),Status = Statuses[5], DateModified = null},
                new Order {DateCreated = DateTime.Parse("2019-08-19T14:35:42Z"),Status = Statuses[2], DateModified = null},
                new Order {DateCreated = DateTime.Parse("2019-08-20T04:53:33Z"),Status = Statuses[0], DateModified = null},
                new Order {DateCreated = DateTime.Parse("2019-12-24T01:30:26Z"),Status = Statuses[6], DateModified = null},
                new Order {DateCreated = DateTime.Parse("2019-11-01T12:01:22Z"),Status = Statuses[0], DateModified = DateTime.Parse("2020-01-26T07:36:39Z")},
                new Order {DateCreated = DateTime.Parse("2020-06-26T08:26:35Z"),Status = Statuses[1], DateModified = null},
                new Order {DateCreated = DateTime.Parse("2020-06-02T00:00:58Z"),Status = Statuses[3], DateModified = null},
                new Order {DateCreated = DateTime.Parse("2019-08-24T01:19:17Z"),Status = Statuses[3], DateModified = DateTime.Parse("2020-04-29T04:19:30Z")},
                new Order {DateCreated = DateTime.Parse("2019-07-18T02:30:02Z"),Status = Statuses[2], DateModified = DateTime.Parse("2020-06-10T19:35:36Z")},
                new Order {DateCreated = DateTime.Parse("2020-06-23T06:53:05Z"),Status = Statuses[2], DateModified = DateTime.Parse("2019-12-14T17:53:21Z")},
                new Order {DateCreated = DateTime.Parse("2019-11-26T03:38:58Z"),Status = Statuses[2], DateModified = null},
                new Order {DateCreated = DateTime.Parse("2020-05-20T02:22:47Z"),Status = Statuses[6], DateModified = null},
                new Order {DateCreated = DateTime.Parse("2019-11-02T17:39:55Z"),Status = Statuses[5], DateModified = DateTime.Parse("2019-10-15T10:19:38Z")},
                new Order {DateCreated = DateTime.Parse("2020-04-17T18:40:36Z"),Status = Statuses[1], DateModified = null},
                new Order {DateCreated = DateTime.Parse("2020-01-29T05:15:54Z"),Status = Statuses[4], DateModified = null},
                new Order {DateCreated = DateTime.Parse("2020-05-04T16:12:24Z"),Status = Statuses[1], DateModified = DateTime.Parse("2019-09-03T10:45:04Z")},
                new Order {DateCreated = DateTime.Parse("2019-12-10T18:44:49Z"),Status = Statuses[4], DateModified = null},
                new Order {DateCreated = DateTime.Parse("2020-04-18T02:38:31Z"),Status = Statuses[5], DateModified = DateTime.Parse("2020-01-14T18:52:53Z")},
                new Order {DateCreated = DateTime.Parse("2019-09-03T10:11:41Z"),Status = Statuses[2], DateModified = DateTime.Parse("2020-06-27T09:11:48Z")},
                new Order {DateCreated = DateTime.Parse("2019-10-27T07:17:46Z"),Status = Statuses[2], DateModified = DateTime.Parse("2019-10-09T22:23:39Z")},
                new Order {DateCreated = DateTime.Parse("2020-05-23T00:16:11Z"),Status = Statuses[5], DateModified = null},
                new Order {DateCreated = DateTime.Parse("2020-02-10T05:51:43Z"),Status = Statuses[2], DateModified = DateTime.Parse("2019-11-10T23:21:21Z")},
                new Order {DateCreated = DateTime.Parse("2020-05-08T14:35:08Z"),Status = Statuses[1], DateModified = DateTime.Parse("2020-06-24T03:16:01Z")},
                new Order {DateCreated = DateTime.Parse("2019-09-14T08:48:10Z"),Status = Statuses[6], DateModified = DateTime.Parse("2019-09-05T08:40:03Z")},
                new Order {DateCreated = DateTime.Parse("2019-12-22T15:39:36Z"),Status = Statuses[0], DateModified = null},
                new Order {DateCreated = DateTime.Parse("2019-11-07T08:37:46Z"),Status = Statuses[1], DateModified = DateTime.Parse("2019-09-13T10:40:12Z")},
                new Order {DateCreated = DateTime.Parse("2020-05-04T00:03:56Z"),Status = Statuses[3], DateModified = null},
                new Order {DateCreated = DateTime.Parse("2019-12-18T20:23:10Z"),Status = Statuses[2], DateModified = null},
                new Order {DateCreated = DateTime.Parse("2019-11-22T04:51:20Z"),Status = Statuses[1], DateModified = null},
                new Order {DateCreated = DateTime.Parse("2019-12-17T20:52:01Z"),Status = Statuses[6], DateModified = null},
                new Order {DateCreated = DateTime.Parse("2019-08-17T22:03:35Z"),Status = Statuses[3], DateModified = DateTime.Parse("2020-02-10T00:27:44Z")},
                new Order {DateCreated = DateTime.Parse("2020-04-12T05:48:33Z"),Status = Statuses[4], DateModified = DateTime.Parse("2019-07-15T09:03:23Z")},
                new Order {DateCreated = DateTime.Parse("2020-04-10T16:28:35Z"),Status = Statuses[3], DateModified = null},
                new Order {DateCreated = DateTime.Parse("2020-06-03T19:58:30Z"),Status = Statuses[3], DateModified = null},
                new Order {DateCreated = DateTime.Parse("2019-12-13T08:18:45Z"),Status = Statuses[2], DateModified = DateTime.Parse("2019-10-26T09:30:10Z")},
                new Order {DateCreated = DateTime.Parse("2019-08-25T18:31:03Z"),Status = Statuses[2], DateModified = null},
                new Order {DateCreated = DateTime.Parse("2019-11-10T00:11:11Z"),Status = Statuses[3], DateModified = DateTime.Parse("2019-12-03T00:28:28Z")},
                new Order {DateCreated = DateTime.Parse("2019-11-11T19:07:36Z"),Status = Statuses[4], DateModified = null},
                new Order {DateCreated = DateTime.Parse("2020-04-15T00:09:00Z"),Status = Statuses[3], DateModified = null},
                new Order {DateCreated = DateTime.Parse("2020-02-11T07:08:05Z"),Status = Statuses[4], DateModified = null},
                new Order {DateCreated = DateTime.Parse("2019-09-25T17:52:19Z"),Status = Statuses[2], DateModified = DateTime.Parse("2019-12-27T11:05:38Z")},
                new Order {DateCreated = DateTime.Parse("2020-06-08T07:52:40Z"),Status = Statuses[5], DateModified = DateTime.Parse("2020-03-21T03:19:08Z")},
                new Order {DateCreated = DateTime.Parse("2020-02-22T15:59:41Z"),Status = Statuses[0], DateModified = null},
                new Order {DateCreated = DateTime.Parse("2020-05-10T12:25:29Z"),Status = Statuses[2], DateModified = null}
            };

            OrderItems = new List<OrderItem>
            {
                new OrderItem {Order=Orders[21],Product = Products[7],Quantity = 6, ProductPrice = Products[7].Price},
                new OrderItem {Order=Orders[15],Product = Products[13],Quantity = 9, ProductPrice = Products[13].Price},
                new OrderItem {Order=Orders[29],Product = Products[9],Quantity = 8, ProductPrice = Products[9].Price},
                new OrderItem {Order=Orders[45],Product = Products[25],Quantity = 9, ProductPrice = Products[25].Price},
                new OrderItem {Order=Orders[21],Product = Products[8],Quantity = 6, ProductPrice = Products[8].Price},
                new OrderItem {Order=Orders[16],Product = Products[6],Quantity = 8, ProductPrice = Products[6].Price},
                new OrderItem {Order=Orders[11],Product = Products[4],Quantity = 9, ProductPrice = Products[4].Price},
                new OrderItem {Order=Orders[43],Product = Products[16],Quantity = 3, ProductPrice = Products[16].Price},
                new OrderItem {Order=Orders[38],Product = Products[0],Quantity = 6, ProductPrice = Products[0].Price},
                new OrderItem {Order=Orders[41],Product = Products[12],Quantity = 7, ProductPrice = Products[12].Price},
                new OrderItem {Order=Orders[22],Product = Products[20],Quantity = 6, ProductPrice = Products[20].Price},
                new OrderItem {Order=Orders[27],Product = Products[18],Quantity = 5, ProductPrice = Products[18].Price},
                new OrderItem {Order=Orders[31],Product = Products[19],Quantity = 7, ProductPrice = Products[19].Price},
                new OrderItem {Order=Orders[49],Product = Products[6],Quantity = 4, ProductPrice = Products[6].Price},
                new OrderItem {Order=Orders[7],Product = Products[4],Quantity = 1, ProductPrice = Products[4].Price},
                new OrderItem {Order=Orders[2],Product = Products[6],Quantity = 6, ProductPrice = Products[6].Price},
                new OrderItem {Order=Orders[36],Product = Products[16],Quantity = 4, ProductPrice = Products[16].Price},
                new OrderItem {Order=Orders[5],Product = Products[18],Quantity = 3, ProductPrice = Products[18].Price},
                new OrderItem {Order=Orders[44],Product = Products[1],Quantity = 2, ProductPrice = Products[1].Price},
                new OrderItem {Order=Orders[16],Product = Products[4],Quantity = 5, ProductPrice = Products[4].Price},
                new OrderItem {Order=Orders[20],Product = Products[22],Quantity = 4, ProductPrice = Products[22].Price},
                new OrderItem {Order=Orders[2],Product = Products[24],Quantity = 9, ProductPrice = Products[24].Price},
                new OrderItem {Order=Orders[30],Product = Products[18],Quantity = 4, ProductPrice = Products[18].Price},
                new OrderItem {Order=Orders[47],Product = Products[14],Quantity = 9, ProductPrice = Products[14].Price},
                new OrderItem {Order=Orders[21],Product = Products[25],Quantity = 6, ProductPrice = Products[25].Price},
                new OrderItem {Order=Orders[16],Product = Products[2],Quantity = 9, ProductPrice = Products[2].Price},
                new OrderItem {Order=Orders[22],Product = Products[3],Quantity = 3, ProductPrice = Products[3].Price},
                new OrderItem {Order=Orders[44],Product = Products[10],Quantity = 2, ProductPrice = Products[10].Price},
                new OrderItem {Order=Orders[11],Product = Products[17],Quantity = 6, ProductPrice = Products[17].Price},
                new OrderItem {Order=Orders[4],Product = Products[13],Quantity = 9, ProductPrice = Products[13].Price},
                new OrderItem {Order=Orders[39],Product = Products[17],Quantity = 5, ProductPrice = Products[17].Price},
                new OrderItem {Order=Orders[23],Product = Products[12],Quantity = 7, ProductPrice = Products[12].Price},
                new OrderItem {Order=Orders[39],Product = Products[11],Quantity = 6, ProductPrice = Products[11].Price},
                new OrderItem {Order=Orders[20],Product = Products[2],Quantity = 1, ProductPrice = Products[2].Price},
                new OrderItem {Order=Orders[1],Product = Products[5],Quantity = 5, ProductPrice = Products[5].Price},
                new OrderItem {Order=Orders[10],Product = Products[8],Quantity = 5, ProductPrice = Products[8].Price},
                new OrderItem {Order=Orders[28],Product = Products[10],Quantity = 3, ProductPrice = Products[10].Price},
                new OrderItem {Order=Orders[47],Product = Products[11],Quantity = 7, ProductPrice = Products[11].Price},
                new OrderItem {Order=Orders[23],Product = Products[3],Quantity = 6, ProductPrice = Products[3].Price},
                new OrderItem {Order=Orders[22],Product = Products[14],Quantity = 9, ProductPrice = Products[14].Price},
                new OrderItem {Order=Orders[10],Product = Products[18],Quantity = 2, ProductPrice = Products[18].Price},
                new OrderItem {Order=Orders[10],Product = Products[15],Quantity = 2, ProductPrice = Products[15].Price},
                new OrderItem {Order=Orders[17],Product = Products[0],Quantity = 2, ProductPrice = Products[0].Price},
                new OrderItem {Order=Orders[15],Product = Products[16],Quantity = 8, ProductPrice = Products[16].Price},
                new OrderItem {Order=Orders[22],Product = Products[24],Quantity = 2, ProductPrice = Products[24].Price},
                new OrderItem {Order=Orders[17],Product = Products[15],Quantity = 9, ProductPrice = Products[15].Price},
                new OrderItem {Order=Orders[40],Product = Products[12],Quantity = 2, ProductPrice = Products[12].Price},
                new OrderItem {Order=Orders[6],Product = Products[1],Quantity = 4, ProductPrice = Products[1].Price},
                new OrderItem {Order=Orders[24],Product = Products[14],Quantity = 9, ProductPrice = Products[14].Price},
                new OrderItem {Order=Orders[2],Product = Products[19],Quantity = 9, ProductPrice = Products[19].Price},
                new OrderItem {Order=Orders[39],Product = Products[4],Quantity = 8, ProductPrice = Products[4].Price},
                new OrderItem {Order=Orders[33],Product = Products[14],Quantity = 2, ProductPrice = Products[14].Price},
                new OrderItem {Order=Orders[17],Product = Products[12],Quantity = 9, ProductPrice = Products[12].Price},
                new OrderItem {Order=Orders[3],Product = Products[21],Quantity = 6, ProductPrice = Products[21].Price},
                new OrderItem {Order=Orders[9],Product = Products[4],Quantity = 2, ProductPrice = Products[4].Price},
                new OrderItem {Order=Orders[42],Product = Products[0],Quantity = 2, ProductPrice = Products[0].Price},
                new OrderItem {Order=Orders[15],Product = Products[11],Quantity = 8, ProductPrice = Products[11].Price},
                new OrderItem {Order=Orders[12],Product = Products[23],Quantity = 7, ProductPrice = Products[23].Price},
                new OrderItem {Order=Orders[41],Product = Products[18],Quantity = 1, ProductPrice = Products[18].Price},
                new OrderItem {Order=Orders[22],Product = Products[12],Quantity = 6, ProductPrice = Products[12].Price},
                new OrderItem {Order=Orders[48],Product = Products[19],Quantity = 7, ProductPrice = Products[19].Price},
                new OrderItem {Order=Orders[45],Product = Products[7],Quantity = 4, ProductPrice = Products[7].Price},
                new OrderItem {Order=Orders[39],Product = Products[19],Quantity = 6, ProductPrice = Products[19].Price},
                new OrderItem {Order=Orders[13],Product = Products[0],Quantity = 7, ProductPrice = Products[0].Price},
                new OrderItem {Order=Orders[33],Product = Products[20],Quantity = 4, ProductPrice = Products[20].Price},
                new OrderItem {Order=Orders[28],Product = Products[16],Quantity = 1, ProductPrice = Products[16].Price},
                new OrderItem {Order=Orders[5],Product = Products[21],Quantity = 6, ProductPrice = Products[21].Price},
                new OrderItem {Order=Orders[32],Product = Products[7],Quantity = 2, ProductPrice = Products[7].Price},
                new OrderItem {Order=Orders[35],Product = Products[3],Quantity = 8, ProductPrice = Products[3].Price},
                new OrderItem {Order=Orders[26],Product = Products[19],Quantity = 5, ProductPrice = Products[19].Price},
                new OrderItem {Order=Orders[12],Product = Products[16],Quantity = 7, ProductPrice = Products[16].Price}
            };
        }
        
        public static async Task SeedSampleDataAsync(AppDbContext context)
        {
            if (context.Products.Any() &&
                context.Statuses.Any() &&
                context.Orders.Any() &&
                context.OrderItems.Any()) return;
            
            await context.Products.AddRangeAsync(Products);
            await context.Statuses.AddRangeAsync(Statuses);
            await context.Orders.AddRangeAsync(Orders);
            await context.OrderItems.AddRangeAsync(OrderItems);
            
            await context.SaveChangesAsync();
        }
    }
}