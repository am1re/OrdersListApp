using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Products.Commands.Update
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, int>
    {
        private readonly IAppDbContext _context;

        public UpdateProductCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Products.FindAsync(request.Id);
            
            if (entity == null) 
                throw new NotFoundException(nameof(Product), request.Id);
            
            entity.Name = request.Name ?? entity.Name;
            entity.Price = request.Price ?? entity.Price;
            entity.PhotoUrl = request.PhotoUrl ?? entity.PhotoUrl;

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}