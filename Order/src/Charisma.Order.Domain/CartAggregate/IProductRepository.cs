using Charisma.Framework.Domain.Interfaces;
using Charisma.Order.Domain.ProductAggregate;
using System.Linq.Expressions;

namespace Charisma.Order.Domain.CartAggregate;

public interface IProductRepository : IRepository<Product,int>
{ 

	Task<List<Product>> GetAll(Expression<Func<Product, bool>> predicate);
	
}
