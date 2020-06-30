using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Statuses.Commands.Delete
{
    public class DeleteStatusCommandHandler : IRequestHandler<DeleteStatusCommand>
    {
        private readonly IAppDbContext _context;

        public DeleteStatusCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteStatusCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Statuses.FindAsync(request.Id);
            if (entity == null) 
                throw new NotFoundException(nameof(Status), request.Id);

            var ordersExists = _context.Orders.Any(o => o.StatusId == request.Id);
            if (ordersExists)
                throw new DeleteFailureException(nameof(Status), request.Id, "There are Orders using this status.");

            _context.Statuses.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}