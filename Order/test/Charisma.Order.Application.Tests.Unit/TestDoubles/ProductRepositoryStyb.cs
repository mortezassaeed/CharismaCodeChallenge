using Charisma.Order.Domain.CartAggregate;
using Charisma.Order.Domain.ProductAggregate;
using System.Linq.Expressions;

namespace Charisma.Order.Application.Tests.Unit.TestDoubles;

internal class ProductRepositoryStub : IProductRepository
{
	public Task<int> CreateAsync(Product entity)
	{
		throw new NotImplementedException();
	}

	public Task DeleteAsync(int id)
	{
		throw new NotImplementedException();
	}

	public async Task<List<Product>> GetAll(Expression<Func<Product, bool>> EarnsMoreThanParent)
	{
		return await Task.FromResult(new List<Product>()
			{ new Product("Product1") { ProductCode = "P_1" , Id = 1 },
			  new Product("Product2") { ProductCode = "P_2" , Id = 2 }
			}
		);
	}

	public async Task<IEnumerable<Product>> GetAllAsync()
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
}
