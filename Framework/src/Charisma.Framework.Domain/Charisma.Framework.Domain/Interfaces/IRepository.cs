using Charisma.Framework.Domain.Concrete;

namespace Charisma.Framework.Domain.Interfaces;

public interface IRepository<T, TKey>
{
	Task<T?> GetByIdAsync(TKey id);
	Task<IEnumerable<T>> GetAllAsync();
	Task<TKey> CreateAsync(T entity);
	Task DeleteAsync(TKey id);
	Task UpdateAsync(T entity);
}
