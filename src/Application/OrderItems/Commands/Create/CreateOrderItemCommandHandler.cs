﻿using System.Linq;
 using System.Threading;
using System.Threading.Tasks;
 using Application.Common.Exceptions;
 using Application.Common.Interfaces;
 using Domain.Entities;
 using MediatR;
 using Microsoft.EntityFrameworkCore;

 namespace Application.OrderItems.Commands.Create
{
    public class CreateOrderItemCommandHandler : IRequestHandler<CreateOrderItemCommand, (int orderId, int productId)>
    {
        private readonly IAppDbContext _context;

        public CreateOrderItemCommandHandler(IAppDbContext context)
        {
            _context = context;
        }
        
        public async Task<(int orderId, int productId)> Handle(CreateOrderItemCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.Where(e => e.Id == request.ProductId)
                .SingleOrDefaultAsync(cancellationToken);
            
            if(product == null)
                throw new NotFoundException(nameof(Product), request.ProductId);
                
            var entity = new OrderItem
            {
                OrderId = request.OrderId,
                ProductId = request.ProductId,
                ProductPrice = product.Price,
                Quantity = request.Quantity
            };
            
            await _context.OrderItems.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return (entity.OrderId, entity.ProductId);
        }
    }
}