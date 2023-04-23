using Charisma.Framework.Domain.CommonValueObject;
using Charisma.Framework.Domain.Concrete;
using Charisma.Order.Domain.ProductAggregate;

namespace Charisma.Order.Domain.CartAggregate;

public class CartItem : BaseEntity<int>
{
	public int ProductId { get; set; }
	public Product Product { get; set; }
	public Price? Price { get; set; }


	public void AddProduct(int productId)
	{
		ProductId = productId;
	}

	public void AddPrice(Price price)
	{

		Price = price;
	}

}
