using Charisma.Submission.Domain.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Charisma.Submission.Infra.SQLEF.Repository;

internal class ProductRepository : IProductRepository
{
	private readonly IDbContextFactory<SubmissionDbContext> _dbFactory;

	public ProductRepository(IDbContextFactory<SubmissionDbContext> dbFactory)
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
	public async Task<Product?> GetAsync(Expression<Func<Product, bool>> predicate)
	{
		using var db = _dbFactory.CreateDbContext();
		var product = await db.Product.FirstOrDefaultAsync(predicate);
		return product;
	}
}
