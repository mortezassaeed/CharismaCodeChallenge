namespace Charisma.Framework.Domain.DomainEvents;

internal interface IEventBus
{
	void Publish<T>(T entity) where T : DomainEvent;
}

