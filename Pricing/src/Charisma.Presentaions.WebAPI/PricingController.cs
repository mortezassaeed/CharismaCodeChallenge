using Charisma.Pricing.Application.Contracts.Dtos;
using Charisma.Pricing.Application.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace Charisma.Presentaions.WebAPI;

[ApiController]
[Route("api/[controller]")]
public class PricingController : ControllerBase
{
	private readonly ICalculatePriceService _calculatePriceService;

	public PricingController(ICalculatePriceService calculatePriceService)
	{
		_calculatePriceService = calculatePriceService;
	}

	[HttpGet]
	public async Task<IActionResult> Create()
	{
		return Ok();
	}

	[HttpPost]
	public async Task<IActionResult> Create(CalculatePriceCreateDto data)
	{
		var result = await _calculatePriceService.CalculateFinalPrice(data);
		return Ok(result);
	}


}
