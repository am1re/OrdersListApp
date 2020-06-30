using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Orders.Commands.Delete
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
    {
        private readonly IAppDbContext _context;

        public DeleteOrderCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Orders.Include(o => o.OrderItems)
                .SingleOrDefaultAsync(o => o.Id == request.Id, cancellationToken);

            if (entity == null) 
                throw new NotFoundException(nameof(Order), request.Id);
            
            _context.OrderItems.RemoveRange(entity.OrderItems);
            _context.Orders.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}