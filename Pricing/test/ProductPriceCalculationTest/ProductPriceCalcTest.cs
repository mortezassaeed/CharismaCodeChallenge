using Charisma.Pricing.Application.CommandHandler;
using Charisma.Pricing.Application.Contracts.Dtos;
using Charisma.Pricing.Domain.PricingAggregate;
using FluentAssertions;
using NSubstitute;
using ProductPriceCalculationTest.TestDoubles;

namespace ProductPriceCalculationTest;


public class ProductPriceCalcTest
{
	[Theory]
	[InlineData(1_000, 1, 1_900)]
	[InlineData(1_000, 2, 2_000)]
	[InlineData(20_000, 2, 20_800)]
	[InlineData(20_000, 5, 20_700)]
	public async Task calculation_price_command_should_calculate_properly(decimal actualPriceAmount, int customerId, decimal expectedPriceAmount)
	{
		var stabProcutReop = new ProductRepositoryStab(actualPriceAmount);
		var fakeProcutPricingReop = Substitute.For<IProductPricingRepository>();
		var service = new CalculatePriceService(stabProcutReop, fakeProcutPricingReop);

		var result = await service.CalculateFinalPrice(new CalculatePriceCreateDto("P_Sample", customerId));

		result.Price.Should().Be(expectedPriceAmount);
	}
}