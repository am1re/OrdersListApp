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
    public class GetOrderDetailQueryHandler : IRequestHandler<GetOrderDetailQuery, OrderDetailVm>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetOrderDetailQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OrderDetailVm> Handle(GetOrderDetailQuery request, CancellationToken cancellationToken)
        {
            var res = await _context.Orders
                .Where(e => e.Id == request.Id)
                .ProjectTo<OrderDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(cancellationToken);
                
            return new OrderDetailVm
            {
                Data = res ?? throw new NotFoundException(nameof(Order), request.Id)
            };
        }
    }
}