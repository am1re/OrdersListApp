using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.OrderItems.Commands.Update
{
    public class UpdateOrderItemCommandHandler : IRequestHandler<UpdateOrderItemCommand, (int orderId, int productId)>
    {
        private readonly IAppDbContext _context;

        public UpdateOrderItemCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<(int orderId, int productId)> Handle(UpdateOrderItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.OrderItems.FindAsync(request.OrderId, request.ProductId);
            if (entity == null) 
                throw new NotFoundException(nameof(OrderItem), (request.OrderId, request.ProductId));
            
            entity.Quantity = request.Quantity ?? entity.Quantity;

            await _context.SaveChangesAsync(cancellationToken);

            return (entity.OrderId, entity.ProductId);
        }
    }
}