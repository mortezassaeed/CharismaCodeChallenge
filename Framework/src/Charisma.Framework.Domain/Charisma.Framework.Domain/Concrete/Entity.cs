namespace Charisma.Framework.Domain.Concrete;

  
public abstract class BaseEntity<TKey>
{
	public TKey Id { get; set; }

}
