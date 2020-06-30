using System.Threading.Tasks;
using Application.OrderItems.Commands.Create;
using Application.OrderItems.Commands.Delete;
using Application.OrderItems.Commands.Update;
using Application.OrderItems.Queries.GetDetail;
using Application.OrderItems.Queries.GetList;
using Application.Orders.Commands.Create;
using Application.Orders.Commands.Delete;
using Application.Orders.Commands.Update;
using Application.Orders.Queries.GetDetail;
using Application.Orders.Queries.GetList;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class OrdersController : BaseController
    {
        [HttpGet("{id}/Items")]
        public async Task<ActionResult<OrderItemsListVm>> GetItemsByOrderId(int id, [FromQuery] GetOrderItemsListQuery query)
        {
            query.OrderId = id;
            return Ok(await Mediator.Send(query));
        }        
        
        [HttpPost("{id}/Items")]
        public async Task<ActionResult<OrderItemDetailVm>> CreateItemByOrderId(int id, [FromBody] CreateOrderItemCommand command)
        {
            command.OrderId = id;
            var (orderId, productId) = await Mediator.Send(command);
            var result = await Mediator.Send(new GetOrderItemDetailQuery { OrderId = orderId, ProductId = productId });
            return Ok(result);
        }
        
        [HttpPut("{id}/Items")]
        public async Task<ActionResult<OrderItemDetailVm>> UpdateItemByOrderId(int id, [FromBody] UpdateOrderItemCommand command)
        {
            command.OrderId = id;
            var (orderId, productId) = await Mediator.Send(command);
            var result = await Mediator.Send(new GetOrderItemDetailQuery { OrderId = orderId, ProductId = productId });
            return Ok(result);
        }
        
        [HttpDelete("{id}/Items")]
        public async Task<IActionResult> DeleteItemByOrderId([FromRoute] int id, [FromBody] DeleteOrderItemCommand command)
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
        public async Task<ActionResult<OrderDetailVm>> Get(int id)
        {
            return Ok(await Mediator.Send(new GetOrderDetailQuery { Id = id }));
        }
        
        [HttpPost]
        public async Task<ActionResult<OrderDetailVm>> Create([FromBody] CreateOrderCommand command)
        {
            var resultId = await Mediator.Send(command);
            var result = await Mediator.Send(new GetOrderDetailQuery { Id = resultId });
            return Ok(result);
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<OrderDetailVm>> Update(int id, [FromBody] UpdateOrderCommand command)
        {
            command.Id = id;
            var resultId = await Mediator.Send(command);
            var result = await Mediator.Send(new GetOrderDetailQuery { Id = resultId });
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteOrderCommand { Id = id });
            return NoContent();
        }
    }

}