using Charisma.Framework.Domain.Concrete;

namespace Charisma.Order.Domain.ProductAggregate;

public class Product : AggregateRoot<int>
{
	public string Name { get; private set; }
	public string ProductCode { get; set; }
	public Product(string name)
	{
		Name = name;
	}
}
