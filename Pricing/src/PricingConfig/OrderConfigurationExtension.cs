using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Charisma.Pricing.Infra.Persistence.SQlEF;
using Charisma.Pricing.Application;

namespace PricingConfig;

public static class PricingConfigurationExtension
{
	public static void UsePricing(this IServiceCollection services, IConfiguration configuration)
	{
		services.UsePricingEFDataAccess(configuration);
		services.UsePricingApplication();
	}
}