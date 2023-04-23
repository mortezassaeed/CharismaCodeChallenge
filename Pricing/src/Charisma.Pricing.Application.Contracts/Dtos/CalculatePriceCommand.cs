using Charisma.Framework.Application;


namespace Charisma.Pricing.Application.Contracts.Dtos;

public record CalculatePriceCreateDto(string productCode, int customerId);
public record CalculatePriceCreateResponseDto(string ProductCode, decimal Price);
