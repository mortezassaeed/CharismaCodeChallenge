namespace Charisma.Framework.Domain.DomainEvents;
public abstract record DomainEvent
{
	public Guid Id { get; private set; }
	public DateTime PublishDate { get; private set; }

	protected DomainEvent()
	{
		Id = Guid.NewGuid();
		PublishDate = DateTime.Now;
	}
}