using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.VmWrappers;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.OrderItems.Queries.GetList
{
    public class GetOrderItemsListQueryHandler : IRequestHandler<GetOrderItemsListQuery, OrderItemsListVm>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetOrderItemsListQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OrderItemsListVm> Handle(GetOrderItemsListQuery request, CancellationToken token)
        {
            if (request.OrderId.HasValue && !_context.Orders.Any(o => o.Id == request.OrderId))
                throw new NotFoundException(nameof(Order), request.OrderId);

            var query = _context.OrderItems.AsQueryable();
            
            query = request.OrderId.HasValue
                ? query.Where(item => item.OrderId == request.OrderId.Value)
                : query;
            
            var total = query.Count();
            query = query.Skip(request.Offset).Take(request.Limit);
                
            var orderItems = await query.ProjectTo<OrderItemDto>(_mapper.ConfigurationProvider).ToListAsync(token);

            return new OrderItemsListVm
            {
                Pagination = new PaginationInfo
                {
                    Limit = request.Limit,
                    Offset = request.Offset,
                    Count = orderItems.Count,
                    Total = total
                },
                Data = orderItems
            };
        }
    }
}