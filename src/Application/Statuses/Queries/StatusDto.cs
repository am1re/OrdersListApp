using Application.Common.Mapping;
using Domain.Entities;

namespace Application.Statuses.Queries
{
    public class StatusDto : IMapFrom<Status>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}