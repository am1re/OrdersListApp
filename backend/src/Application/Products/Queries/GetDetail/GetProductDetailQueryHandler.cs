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

namespace Application.Products.Queries.GetDetail
{
    public class GetProductDetailQueryHandler : IRequestHandler<GetProductDetailQuery, ProductDetailVm>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetProductDetailQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductDetailVm> Handle(GetProductDetailQuery request, CancellationToken cancellationToken)
        {
            var res = await _context.Products
                .Where(e => e.Id == request.Id)
                .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(cancellationToken);
                
            return new ProductDetailVm
            {
                Data = res ?? throw new NotFoundException(nameof(Product), request.Id)
            };
        }
    }
}