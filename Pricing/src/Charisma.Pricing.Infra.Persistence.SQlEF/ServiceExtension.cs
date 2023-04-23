using Charisma.Pricing.Domain.PricingAggregate;
using Charisma.Pricing.Domain.ProductAggregate;
using Charisma.Pricing.Infra.Persistence.SQlEF.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Charisma.Pricing.Infra.Persistence.SQlEF;

public static class ServiceExtension
{
	public static void UsePricingEFDataAccess(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContextFactory<PricingDbContext>(opt =>
			opt.UseSqlServer(configuration.GetConnectionString("Default")
			));
		services.AddSingleton<IProductRepository, ProductRepository>();
		services.AddSingleton<IProductPricingRepository, ProductPricingRepository>();
	}
}
