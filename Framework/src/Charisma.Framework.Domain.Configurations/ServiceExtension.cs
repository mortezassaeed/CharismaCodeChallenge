using Charisma.Framework.Domain.Configurations.Event;
using Charisma.Framework.Domain.DomainEvents;
using Microsoft.Extensions.DependencyInjection;

namespace Charisma.Framework.Domain.Configurations;

public static class ServiceExtension
{
	public static void UseCommandAndHandler(this IServiceCollection services)
	{
		services.AddSingleton<IEventBus, EventBus>();
	}
}