using Charisma.Framework.Domain.CommonValueObject;
using Charisma.Framework.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Charisma.Order.Domain.ProductAggregate;

public class Product : AggregateRoot<int>
{
    public string Name { get; private set; }

    public Product(string name)
	{
		Name = name;
	}
}
