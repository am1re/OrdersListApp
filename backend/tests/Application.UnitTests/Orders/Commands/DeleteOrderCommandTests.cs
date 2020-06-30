using System.Threading;
using System.Threading.Tasks;
using Application.Orders.Commands.Delete;
using Application.UnitTests.Common;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Application.UnitTests.Orders.Commands
{
    [Collection("AppDataCollection")]
    public class DeleteOrderCommandTests
    {
        private readonly DeleteOrderCommandHandler _sut;
        private readonly AppDbContext _context;
        
        public DeleteOrderCommandTests(AppDataTestFixture fixture)
        {
            _context = fixture.Context;
            _sut = new DeleteOrderCommandHandler(fixture.Context);
        }

        [Fact]
        public async Task Handle_GivenValidId_DeletedOrder()
        {
            var order = await _context.Orders.FirstOrDefaultAsync();
            if (order == null) return;
            
            var command = new DeleteOrderCommand { Id = order.Id };
            await _sut.Handle(command, CancellationToken.None);
            
            var orderDeleted = await _context.Orders.FindAsync(order.Id);
            Assert.Null(orderDeleted);
        }
    }
}