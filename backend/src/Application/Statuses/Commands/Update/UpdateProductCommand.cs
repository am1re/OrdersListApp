using MediatR;

namespace Application.Statuses.Commands.Update
{
    public class UpdateStatusCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}