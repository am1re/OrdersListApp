using System.Threading;
using System.Threading.Tasks;
using Application.Orders.Commands.Update;
using Application.UnitTests.Common;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Application.UnitTests.Orders.Commands
{
    [Collection("AppDataCollection")]
    public class UpdateOrderCommandTests
    {
        private readonly UpdateOrderCommandHandler _sut;
        private readonly AppDbContext _context;

        public UpdateOrderCommandTests(AppDataTestFixture fixture)
        {
            _context = fixture.Context;
            _sut = new UpdateOrderCommandHandler(fixture.Context);
        }

        [Fact]
        public async Task Handle_GivenValidData_UpdatesOrder()
        {
            var order = await _context.Orders.FirstOrDefaultAsync();
            if (order == null) return;
            var orderOldStatusId = order.Id;
            var randStatus = await _context.Statuses.FirstOrDefaultAsync(s => s.Id != orderOldStatusId);
            if (randStatus == null) return;
            
            var command = new UpdateOrderCommand { Id = order.Id, StatusId = randStatus.Id };
            var resultId = await _sut.Handle(command, CancellationToken.None);
            
            order = await _context.Orders.FindAsync(resultId);
            Assert.NotNull(order);
            Assert.NotEqual(orderOldStatusId, order.StatusId);
        }
    }
}