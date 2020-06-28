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
        
        public async Task<(int orderId, int productId)> Handle(CreateOrderItemCommand request, CancellationToken token)
        {
            var orderExists = _context.Orders.Any(e => e.Id == request.OrderId);
            if (!orderExists) 
                throw new NotFoundException(nameof(Order), request.OrderId);
            
            var product = await _context.Products.Where(e => e.Id == request.ProductId).SingleOrDefaultAsync(token);
            if (product == null)
                throw new NotFoundException(nameof(Product), request.ProductId);

            var itemExists = _context.OrderItems.Any(o => o.OrderId == request.OrderId && o.ProductId == request.ProductId);
            if (itemExists) 
                throw new ConflictDataException($"Order Item with ID ({request.ProductId},{request.OrderId}) already exists.");

            var entity = new OrderItem
            {
                OrderId = request.OrderId,
                ProductId = request.ProductId,
                ProductPrice = product.Price,
                Quantity = request.Quantity
            };
            
            await _context.OrderItems.AddAsync(entity, token);
            await _context.SaveChangesAsync(token);

            return (entity.OrderId, entity.ProductId);
        }
    }
}