using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Orders.Commands.Update
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, int>
    {
        private readonly IAppDbContext _context;

        public UpdateOrderCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateOrderCommand request, CancellationToken token)
        {
            var entity = await _context.Orders.FindAsync(request.Id);
            if (entity == null) 
                throw new NotFoundException(nameof(Order), request.Id);
            
            var statusExists = _context.Statuses.Any(s => s.Id == request.StatusId);
            if (!statusExists)
                throw new NotFoundException(nameof(Status), request.StatusId);

            entity.StatusId = request.StatusId;
            entity.DateModified = DateTime.Now;
            await _context.SaveChangesAsync(token);

            return entity.Id;
        }
    }
}