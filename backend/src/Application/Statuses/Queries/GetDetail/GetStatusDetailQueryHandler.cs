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

namespace Application.Statuses.Queries.GetDetail
{
    public class GetStatusDetailQueryHandler : IRequestHandler<GetStatusDetailQuery, StatusDetailVm>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetStatusDetailQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<StatusDetailVm> Handle(GetStatusDetailQuery request, CancellationToken cancellationToken)
        {
            var res = await _context.Statuses
                .Where(e => e.Id == request.Id)
                .ProjectTo<StatusDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(cancellationToken);
                
            return new StatusDetailVm
            {
                Data = res ?? throw new NotFoundException(nameof(Status), request.Id)
            };
        }
    }
}