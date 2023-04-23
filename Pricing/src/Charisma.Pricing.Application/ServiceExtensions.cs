using Charisma.Framework.Application;
using Charisma.Framework.Application.Configurations;
using Charisma.Pricing.Application.CommandHandler;
using Charisma.Pricing.Application.Contracts.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Charisma.Pricing.Application;

public static class ServiceExtension
{
	public static void UsePricingApplication(this IServiceCollection services)
	{
		services.AddSingleton<ICalculatePriceService, CalculatePriceService>();
	}
}
