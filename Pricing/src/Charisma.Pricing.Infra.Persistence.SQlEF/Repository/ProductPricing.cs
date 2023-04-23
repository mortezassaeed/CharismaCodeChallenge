using Charisma.Pricing.Domain.PricingAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charisma.Pricing.Infra.Persistence.SQlEF.Repository;

internal class ProductPricingRepository : IProductPricingRepository
{
	private readonly IDbContextFactory<PricingDbContext> _dbFactory;

	public ProductPricingRepository(IDbContextFactory<PricingDbContext> dbFactory)
	{
		_dbFactory = dbFactory;
	}
	public async Task<int> CreateAsync(ProductPricing entity)
	{
		using var db = _dbFactory.CreateDbContext();
		await db.AddAsync(entity);
		await db.SaveChangesAsync();
		return entity.Id;
	}

	public Task DeleteAsync(int id)
	{
		throw new NotImplementedException();
	}

	public Task<IEnumerable<ProductPricing>> GetAllAsync()
	{
		throw new NotImplementedException();
	}

	public Task<ProductPricing?> GetByIdAsync(int id)
	{
		throw new NotImplementedException();
	}

	public Task UpdateAsync(ProductPricing entity)
	{
		throw new NotImplementedException();
	}
}
