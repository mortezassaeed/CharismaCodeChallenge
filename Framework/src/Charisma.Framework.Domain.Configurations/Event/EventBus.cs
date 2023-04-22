using Charisma.Framework.Domain.DomainEvents;
using Microsoft.Extensions.DependencyInjection;


namespace Charisma.Framework.Domain.Configurations.Event;

public class EventBus : IEventBus
{
	private readonly IServiceProvider _services;
	public EventBus(IServiceProvider services)
	{
		_services = services;
	}

	public void Publish<T>(T entity) where T : DomainEvent
	{
		var services = _services.GetRequiredService<IEnumerable<IEventHandler<T>>>();
		foreach (var service in services)
		{
			service.Handle(entity);
		}
	}
}