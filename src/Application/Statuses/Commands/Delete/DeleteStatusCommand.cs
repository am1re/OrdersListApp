using MediatR;

namespace Application.Statuses.Commands.Delete
{
    public class DeleteStatusCommand : IRequest
    {
        public int Id { get; set; }
    }
}