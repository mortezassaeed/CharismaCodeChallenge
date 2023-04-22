namespace Charisma.Framework.Domain.DomainEvents;

public interface IEventHandler<T> where T : DomainEvent
{
	void Handle(T domainEvent);
}
