using Charisma.Framework.Application.Configurations.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace Charisma.Framework.Application.Configurations;

public static class ServiceExtension
{
	public static void UseCommandAndHandler(this IServiceCollection services)
	{
		services.AddSingleton<ICommandBus, CommandBus>();
		services.AddSingleton<IClock, Clock>();
	}
}