using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Orders.Commands.Create;
using Application.UnitTests.Common;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Application.UnitTests.Orders.Commands
{
    [Collection("AppDataCollection")]
    public class CreateOrderCommandTests
    {
        private readonly CreateOrderCommandHandler _sut;
        private readonly AppDbContext _context;

        public CreateOrderCommandTests(AppDataTestFixture fixture)
        {
            _context = fixture.Context;
            _sut = new CreateOrderCommandHandler(fixture.Context, fixture.Mapper);
        }

        [Fact]
        public async Task Handle_GivenValidData_CreatesOrder()
        {
            var statusId = (await _context.Statuses.FirstOrDefaultAsync()).Id;
            var productId = (await _context.Products.FirstOrDefaultAsync()).Id;
            
            var command = new CreateOrderCommand { 
                StatusId = statusId, 
                OrderItems = new List<OrderItemCreateModel>
                {
                    new OrderItemCreateModel { ProductId = productId, Quantity = 1 }
                }};

            var resultId = await _sut.Handle(command, CancellationToken.None);
            
            var order = await _context.Orders.FindAsync(resultId);
            Assert.NotNull(order);
        }
    }
}
