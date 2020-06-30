﻿using System.Threading;
using System.Threading.Tasks;
 using Application.Common.Interfaces;
 using Domain.Entities;
 using MediatR;

namespace Application.Products.Commands.Create
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IAppDbContext _context;

        public CreateProductCommandHandler(IAppDbContext context)
        {
            _context = context;
        }
        
        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = new Product
            {
                Name = request.Name,
                Price = request.Price,
                PhotoUrl = request.PhotoUrl
            };
            
            await _context.Products.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}