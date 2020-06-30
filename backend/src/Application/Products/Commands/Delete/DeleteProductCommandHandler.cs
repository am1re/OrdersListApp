using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Products.Commands.Delete
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IAppDbContext _context;

        public DeleteProductCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Products.FindAsync(request.Id);
            if (entity == null) 
                throw new NotFoundException(nameof(Product), request.Id);

            var ordersExists = _context.OrderItems.Any(o => o.ProductId == request.Id);
            if (ordersExists)
                throw new DeleteFailureException(nameof(Order), request.Id, "There are orders linked to this product.");

            _context.Products.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}