using Charisma.Framework.Domain.CommonValueObject;
using Charisma.Pricing.Application.Contracts.Dtos;
using Charisma.Pricing.Application.Contracts.Services;
using Charisma.Pricing.Application.PipeAndFilter.Builders;
using Charisma.Pricing.Domain.PricingAggregate;
using Charisma.Pricing.Domain.ProductAggregate;


namespace Charisma.Pricing.Application.CommandHandler;

internal class CalculatePriceService : ICalculatePriceService
{
	private readonly IProductRepository _productRepository;
	private readonly IProductPricingRepository _productPricingRepository;

	public CalculatePriceService(IProductRepository productRepository,
									 IProductPricingRepository productPricingRepository)
	{
		_productRepository = productRepository;
		_productPricingRepository = productPricingRepository;
	}

	public async Task<CalculatePriceCreateResponseDto> CalculateFinalPrice(CalculatePriceCreateDto dto)
	{
		var product = await _productRepository.GetAync(dto.productCode);
		var customerId = dto.customerId;
		var finalPrice = new Price(product.BasePrice.Value);

		var filter = new FilterBuilder(customerId, product.BasePrice)
			.AnyOrder().ApplyFixAddedProfit(1000)
			.WhenProductActualPriceMoreThan(2000).ApplyPercentDiscount(1)
			.WhenSpecialCustomer().ApplyFixAmountDiscount(100)
			.Build();

		filter.Apply(dto.customerId, product.BasePrice, finalPrice);

		await _productPricingRepository.CreateAsync(new ProductPricing { ActualPrice = product.BasePrice, FinalPrice = finalPrice, ProductId = product.Id });

		return new CalculatePriceCreateResponseDto(dto.productCode, finalPrice.Value);
	}
}
