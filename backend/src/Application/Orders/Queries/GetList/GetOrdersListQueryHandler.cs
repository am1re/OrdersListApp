using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.VmWrappers;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Orders.Queries.GetList
{
    public class GetOrdersListQueryHandler : IRequestHandler<GetOrdersListQuery, OrdersListVm>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetOrdersListQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OrdersListVm> Handle(GetOrdersListQuery request, CancellationToken token)
        {
            var query = _context.Orders.AsQueryable();
            var total = query.Count();
            query = query.Skip(request.Offset).Take(request.Limit);
                
            var orders = await query.ProjectTo<OrderDto>(_mapper.ConfigurationProvider).ToListAsync(token);

            return new OrdersListVm
            {
                Pagination = new PaginationInfo
                {
                    Limit = request.Limit,
                    Offset = request.Offset,
                    Count = orders.Count,
                    Total = total
                },
                Data = orders
            };
        }
    }
}