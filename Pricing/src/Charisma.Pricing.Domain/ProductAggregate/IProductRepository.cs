using Charisma.Framework.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charisma.Pricing.Domain.ProductAggregate;

public interface IProductRepository : IRepository<Product, int>
{
	public Task<Product> GetAync(string code);

}
