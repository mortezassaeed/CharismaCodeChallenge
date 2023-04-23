using Charisma.Pricing.Application.Contracts.Dtos;

namespace Charisma.Pricing.Application.Contracts.Services;

public interface ICalculatePriceService
{
	Task<CalculatePriceCreateResponseDto> CalculateFinalPrice(CalculatePriceCreateDto dto);
}