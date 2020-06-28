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

namespace Application.Orders.Queries.GetDetail
{
    public class GetOrderItemQueryHandler : IRequestHandler<GetOrderItemQuery, OrderItemVm>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetOrderItemQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OrderItemVm> Handle(GetOrderItemQuery request, CancellationToken cancellationToken)
        {
            var res = await _context.Orders
                .Where(e => e.Id == request.Id)
                .ProjectTo<OrderDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(cancellationToken);
                
            return new OrderItemVm
            {
                Data = res ?? throw new NotFoundException(nameof(Order), request.Id)
            };
        }
    }
}