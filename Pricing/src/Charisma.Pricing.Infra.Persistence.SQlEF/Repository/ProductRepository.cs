using Charisma.Pricing.Domain.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charisma.Pricing.Infra.Persistence.SQlEF.Repository;

internal class ProductRepository : IProductRepository
{
	private readonly IDbContextFactory<PricingDbContext> _dbFactory;

	public ProductRepository(IDbContextFactory<PricingDbContext> dbFactory)
	{
		_dbFactory = dbFactory;
	}

	public Task<int> CreateAsync(Product entity)
	{
		throw new NotImplementedException();
	}

	public Task DeleteAsync(int id)
	{
		throw new NotImplementedException();
	}

	public Task<IEnumerable<Product>> GetAllAsync()
	{
		throw new NotImplementedException();
	}

	public Task<Product?> GetByIdAsync(int id)
	{
		throw new NotImplementedException();
	}

	public Task UpdateAsync(Product entity)
	{
		throw new NotImplementedException();
	}
	public async Task<Product> GetAync(string code)
	{
		using var db = _dbFactory.CreateDbContext();
		return await db.Products.FirstOrDefaultAsync(m => m.ProductCode == code);
	}
}
