using Charisma.Framework.Domain.CommonValueObject;
using Charisma.Framework.Domain.Concrete;
using Charisma.Order.Domain.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charisma.Order.Domain.CartAggregate;

public class CartItem : BaseEntity<int>
{
    public int ProductId { get; set; }
    public Product Product { get; set; }
	public Price? Price { get; set; }

	public void AddProduct(int productId)
    {
        this.ProductId = productId;
    }

}
