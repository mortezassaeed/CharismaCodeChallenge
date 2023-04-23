using Charisma.Framework.Domain.CommonValueObject;
using Charisma.Framework.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charisma.Pricing.Domain.ProductAggregate;

public class Product : AggregateRoot<int>
{
    public string ProductCode { get; set; }
	public Price BasePrice { get; set; }

	public Product(string productCode)
	{
		ProductCode = productCode;
	}

	public void SetBasePrice(Price basePrice)
	{
		BasePrice = basePrice;
	}
}
