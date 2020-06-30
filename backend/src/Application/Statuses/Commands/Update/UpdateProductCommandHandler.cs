using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Statuses.Commands.Update
{
    public class UpdateStatusCommandHandler : IRequestHandler<UpdateStatusCommand, int>
    {
        private readonly IAppDbContext _context;

        public UpdateStatusCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateStatusCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Statuses.FindAsync(request.Id);
            
            if (entity == null) 
                throw new NotFoundException(nameof(Status), request.Id);
            
            entity.Name = request.Name ?? entity.Name;

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}