using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Orderly.Application.Products;
using Orderly.Application.Products.Commands.CreateProduct;
using Orderly.Application.Products.Commands.DeleteProduct;
using Orderly.Application.Products.Commands.UpdateProduct;
using Orderly.Application.Products.DTOs;
using Orderly.Application.Products.Queries.GetAllProducts;
using Orderly.Application.Products.Queries.GetProductById;
using Orderly.Domain.Constants;

namespace Orderly.API.Controllers;

[ApiController]
[Route("api/products")]
[Authorize]
public class ProductsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAll()
    {
        return Ok(await mediator.Send(new GetAllProductsQuery()));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<ProductDTO>>> GetById([FromRoute] int id)
    {
        var product = await mediator.Send(new GetProductByIdQuery(id));
        return Ok(product);

    }

    [HttpPost]
    [Authorize(Roles = UserRoles.Owner)]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
    {
        int id = await mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteProduct([FromRoute] int id)
    {
        await mediator.Send(new DeleteProductCommand(id));
        return NoContent();
    }

    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommand command, [FromRoute] int id)
    {
        command.Id = id;
        await mediator.Send(command);

        return Ok(command);
    }
}
