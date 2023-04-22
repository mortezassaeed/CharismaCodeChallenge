using Microsoft.Extensions.DependencyInjection;
using Charisma.Infrastructure.Persistence.SQLEF;
using Microsoft.Extensions.Configuration;
using Charisma.Order.Application;

namespace OrderConfig;

public static class OrderConfigurationExtension
{
	public static void UseOrder(this IServiceCollection services, IConfiguration configuration)
	{
		services.UseOrderEFDataAccess(configuration);
		services.UseOrderServices();
	}
}
