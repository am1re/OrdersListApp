using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.OrderItems.Commands.Delete
{
    public class DeleteOrderItemCommandHandler : IRequestHandler<DeleteOrderItemCommand>
    {
        private readonly IAppDbContext _context;

        public DeleteOrderItemCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteOrderItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.OrderItems.FindAsync(request.OrderId, request.ProductId);
            
            if (entity == null) 
                throw new NotFoundException(nameof(OrderItem), (request.OrderId, request.ProductId));

            _context.OrderItems.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}