using MediatR;

namespace Application.Statuses.Commands.Create
{
    public class CreateStatusCommand : IRequest<int>
    {
        public string Name { get; set; }
    }
}