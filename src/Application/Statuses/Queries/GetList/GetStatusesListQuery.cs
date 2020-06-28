using MediatR;

namespace Application.Statuses.Queries.GetList
{
    public class GetStatusesListQuery : IRequest<StatusesListVm>
    {
        public int Offset { get; set; } = 0;
        public int Limit { get; set; } = 10;
    }
}