﻿using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Threading;
 using System.Threading.Tasks;
 using Application.Common.Exceptions;
 using Application.Common.Interfaces;
 using AutoMapper;
 using Domain.Entities;
 using MediatR;
 using Microsoft.EntityFrameworkCore;

 namespace Application.Orders.Commands.Create
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IAppDbContext _context;

        public CreateOrderCommandHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
        }
        
        public async Task<int> Handle(CreateOrderCommand request, CancellationToken token)
        {
            var statusExists = _context.Statuses.Any(s => s.Id == request.StatusId);
            if (!statusExists) 
                throw new NotFoundException(nameof(Status), request.StatusId);
            
            request.OrderItems ??= new List<OrderItemCreateModel>();
            var orderItemsAsyncTasks = request.OrderItems.Select(o => ProcessOrderItemAsync(o, token)).ToList();
            var items = await Task.WhenAll(orderItemsAsyncTasks);
            
            var entity = new Order
            {
                StatusId = request.StatusId,
                OrderItems = items,
                DateCreated = DateTime.Now
            };
            
            await _context.Orders.AddAsync(entity, token);
            await _context.SaveChangesAsync(token);

            return entity.Id;
        }

        private async Task<OrderItem> ProcessOrderItemAsync(OrderItemCreateModel item, CancellationToken token)
        {
            var product = await _context.Products.Where(e => e.Id == item.ProductId)
                .SingleOrDefaultAsync(token);
            if (product == null)
                throw new NotFoundException(nameof(Product), item.ProductId);

            var domainItem = new OrderItem
            {
                ProductPrice = product.Price, 
                ProductId = item.ProductId, 
                Quantity = item.Quantity
            };
            return domainItem;
        }
    }
}