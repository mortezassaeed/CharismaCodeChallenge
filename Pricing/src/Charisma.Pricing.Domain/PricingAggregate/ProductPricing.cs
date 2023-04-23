using Charisma.Framework.Domain.CommonValueObject;
using Charisma.Framework.Domain.Concrete;
using Charisma.Framework.Domain.Interfaces;
using Charisma.Pricing.Domain.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charisma.Pricing.Domain.PricingAggregate;

public class ProductPricing : AggregateRoot<int>
{
    public Price FinalPrice { get; set; }
    public Price ActualPrice { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
}
