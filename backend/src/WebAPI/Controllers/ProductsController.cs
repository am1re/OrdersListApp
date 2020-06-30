using System.Threading.Tasks;
using Application.Products.Commands.Create;
using Application.Products.Commands.Delete;
using Application.Products.Commands.Update;
using Application.Products.Queries.GetDetail;
using Application.Products.Queries.GetList;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class ProductsController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<ProductsListVm>> GetAll([FromQuery] GetProductsListQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDetailVm>> Get(int id)
        {
            return Ok(await Mediator.Send(new GetProductDetailQuery { Id = id }));
        }
     
        [HttpPost]
        public async Task<ActionResult<ProductDetailVm>> Create([FromBody] CreateProductCommand command)
        {
            var resultId = await Mediator.Send(command);
            var result = await Mediator.Send(new GetProductDetailQuery { Id = resultId });
            return Ok(result);
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDetailVm>> Update(int id, [FromBody] UpdateProductCommand command)
        {
            command.Id = id;
            var resultId = await Mediator.Send(command);
            var result = await Mediator.Send(new GetProductDetailQuery { Id = resultId });
            return Ok(result);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteProductCommand { Id = id });
            return NoContent();
        }
    }
}