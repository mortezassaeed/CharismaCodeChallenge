using Charisma.Framework.Domain.Interfaces;
using System.Linq.Expressions;

namespace Charisma.Submission.Domain.ProductAggregate;

public interface IProductRepository : IRepository<Product,int>
{
	Task<Product?> GetAsync(Expression<Func<Product,bool>> predicate);
}
