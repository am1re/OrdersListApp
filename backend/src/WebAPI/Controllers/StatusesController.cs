using System.Threading.Tasks;
using Application.Statuses.Commands.Create;
using Application.Statuses.Commands.Delete;
using Application.Statuses.Commands.Update;
using Application.Statuses.Queries.GetDetail;
using Application.Statuses.Queries.GetList;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class StatusesController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<StatusesListVm>> GetAll([FromQuery] GetStatusesListQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<StatusDetailVm>> Get(int id)
        {
            return Ok(await Mediator.Send(new GetStatusDetailQuery { Id = id }));
        }
     
        [HttpPost]
        public async Task<ActionResult<StatusDetailVm>> Create([FromBody] CreateStatusCommand command)
        {
            var resultId = await Mediator.Send(command);
            var result = await Mediator.Send(new GetStatusDetailQuery { Id = resultId });
            return Ok(result);
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<StatusDetailVm>> Update(int id, [FromBody] UpdateStatusCommand command)
        {
            command.Id = id;
            var resultId = await Mediator.Send(command);
            var result = await Mediator.Send(new GetStatusDetailQuery { Id = resultId });
            return Ok(result);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteStatusCommand { Id = id });
            return NoContent();
        }
    }
}