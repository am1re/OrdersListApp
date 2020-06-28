using System.Threading.Tasks;
using Application.OrderItems.Commands.Create;
using Application.OrderItems.Commands.Delete;
using Application.OrderItems.Commands.Update;
using Application.OrderItems.Queries.GetDetail;
using Application.OrderItems.Queries.GetList;
using Application.Orders.Queries.GetDetail;
using Application.Orders.Queries.GetList;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class OrdersController : BaseController
    {
        [HttpGet("{id}/items")]
        public async Task<ActionResult<OrderItemsListVm>> GetDetailsById(int id, [FromQuery] GetOrderItemsListQuery query)
        {
            query.OrderId = id;
            return Ok(await Mediator.Send(query));
        }        
        
        [HttpPost("{id}/items")]
        public async Task<ActionResult<OrderItemDetailVm>> CreateItemById(int id, [FromBody] CreateOrderItemCommand command)
        {
            command.OrderId = id;
            var (orderId, productId) = await Mediator.Send(command);
            var result = await Mediator.Send(new GetOrderItemDetailQuery { OrderId = orderId, ProductId = productId });
            return Ok(result);
        }
        
        [HttpPut("{id}/items")]
        public async Task<ActionResult<OrderItemDetailVm>> UpdateItemById(int id, [FromBody] UpdateOrderItemCommand command)
        {
            command.OrderId = id;
            var (orderId, productId) = await Mediator.Send(command);
            var result = await Mediator.Send(new GetOrderItemDetailQuery { OrderId = orderId, ProductId = productId });
            return Ok(result);
        }
        
        [HttpDelete("{id}/items")]
        public async Task<IActionResult> DeleteItemById(int id, [FromBody] DeleteOrderItemCommand command)
        {
            command.OrderId = id;
            await Mediator.Send(command);
            return NoContent();
        }
        
        
        [HttpGet]
        public async Task<ActionResult<OrdersListVm>> GetAll([FromQuery] GetOrdersListQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderItemVm>> Get(int id)
        {
            return Ok(await Mediator.Send(new GetOrderItemQuery { Id = id }));
        }
        
        [HttpPost]
        public async Task<IActionResult> Create()
        {
            // TODO: implement
            return Ok();
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id)
        {
            // TODO: implement
            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // TODO: implement
            return NoContent();
        }
    }

}