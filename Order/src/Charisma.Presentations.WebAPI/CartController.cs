using Charisma.Framework.Application;
using Charisma.Order.Application.Contract.Commands;
using Charisma.Order.Application.Contract.QueryServices;
using Microsoft.AspNetCore.Mvc;


namespace Charisma.Presentations.WebAPI;

[ApiController]
[Route("api/[controller]")]
public class CartController : ControllerBase
{
	private readonly ICommandBus _commandBus;
	private readonly ICartItemQueryService _cartItemQueryService;
	public CartController(ICommandBus commandBus, ICartItemQueryService cartItemQueryService)
	{
		_commandBus = commandBus;
		_cartItemQueryService = cartItemQueryService;
	}

	[HttpPost]
	public async Task<IActionResult> Create(AddCartCommand command)
	{
		await _commandBus.DispatchAsync(command);
		return Ok();
	}

	[HttpGet("Id")]
	public async Task<IActionResult> Get(Guid id)
	{
		var result = await _cartItemQueryService.Get(id);
		return Ok(result);
	}

	// ..... 
}
