using Charisma.Order.Domain.CartAggregate;
using Charisma.Order.Domain.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Charisma.Infrastructure.Persistence.SQLEF.Repository;

public class ProductRepository : IProductRepository
{

	private readonly IDbContextFactory<OrderDbContext> _contextFactory;

	public ProductRepository(IDbContextFactory<OrderDbContext> contextFactory)
	{
		_contextFactory = contextFactory;
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

	public async Task<List<Product>> GetAll(Expression<Func<Product, bool>> predicate)
	{
		using var db = _contextFactory.CreateDbContext();
		return await db.Products.Where(predicate).ToListAsync();
	}
}
