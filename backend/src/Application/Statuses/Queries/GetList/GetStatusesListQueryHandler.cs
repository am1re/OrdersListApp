using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.VmWrappers;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Statuses.Queries.GetList
{
    public class GetStatusesListQueryHandler : IRequestHandler<GetStatusesListQuery, StatusesListVm>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetStatusesListQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<StatusesListVm> Handle(GetStatusesListQuery request, CancellationToken token)
        {
            var query = _context.Statuses.AsQueryable();
            var total = query.Count();
            query = query.Skip(request.Offset).Take(request.Limit);
                
            var statuses = await query.ProjectTo<StatusDto>(_mapper.ConfigurationProvider).ToListAsync(token);

            return new StatusesListVm
            {
                Pagination = new PaginationInfo
                {
                    Limit = request.Limit,
                    Offset = request.Offset,
                    Count = statuses.Count,
                    Total = total
                },
                Data = statuses
            };
        }
    }
}