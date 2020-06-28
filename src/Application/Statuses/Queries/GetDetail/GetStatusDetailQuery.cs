using MediatR;

namespace Application.Statuses.Queries.GetDetail
{
    public class GetStatusDetailQuery : IRequest<StatusDetailVm>
    {
        public int Id { get; set; }
    }
}