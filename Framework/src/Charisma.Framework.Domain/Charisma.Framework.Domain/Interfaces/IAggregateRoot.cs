namespace Charisma.Framework.Domain.Interfaces;

public interface IAggregateRoot
{
	IReadOnlyList<IDomainEvent> DomainEvents { get; }
}
