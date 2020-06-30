using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.OrderItems.Queries.GetDetail
{
    public class GetOrderItemDetailQueryHandler : IRequestHandler<GetOrderItemDetailQuery, OrderItemDetailVm>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetOrderItemDetailQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OrderItemDetailVm> Handle(GetOrderItemDetailQuery request, CancellationToken cancellationToken)
        {
            var res = await _context.OrderItems
                .Where(e => e.OrderId == request.OrderId && e.ProductId == request.ProductId)
                .ProjectTo<OrderItemDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(cancellationToken);
                
            return new OrderItemDetailVm
            {
                Data = res ?? throw new NotFoundException(nameof(OrderItem), (request.OrderId, request.ProductId))
            };
        }
    }
}