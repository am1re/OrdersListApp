using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.VmWrappers;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Products.Queries.GetList
{
    public class GetProductsListQueryHandler : IRequestHandler<GetProductsListQuery, ProductsListVm>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetProductsListQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductsListVm> Handle(GetProductsListQuery request, CancellationToken token)
        {
            var query = _context.Products.AsQueryable();
            var total = query.Count();
            query = query.Skip(request.Offset).Take(request.Limit);
                
            var products = await query.ProjectTo<ProductDto>(_mapper.ConfigurationProvider).ToListAsync(token);

            return new ProductsListVm
            {
                Pagination = new PaginationInfo
                {
                    Limit = request.Limit,
                    Offset = request.Offset,
                    Count = products.Count,
                    Total = total
                },
                Data = products
            };
        }
    }
}