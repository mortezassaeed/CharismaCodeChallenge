using Charisma.Framework.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charisma.Pricing.Domain.PricingAggregate;

public interface IProductPricingRepository : IRepository<ProductPricing, int>
{

}
