using Charisma.Framework.Domain.Interfaces;

namespace Charisma.Framework.Domain.Concrete;

public abstract class AggregateRoot<TKey> : BaseEntity<TKey>, IAggregateRoot
{
	private List<IDomainEvent> _domainEvents;
	public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

	public AggregateRoot()
	{
		_domainEvents = new List<IDomainEvent>();
	}
}