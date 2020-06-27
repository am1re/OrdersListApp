using System.Threading.Tasks;
using Application.Products.Commands.Create;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class ProductsController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateProductCommand command)
        {
            var id = await Mediator.Send(command);
            return Ok(id);
        }
    }
}