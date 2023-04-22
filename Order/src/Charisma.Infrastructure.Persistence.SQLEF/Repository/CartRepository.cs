using Charisma.Order.Domain.CartAggregate;
using Microsoft.EntityFrameworkCore;

namespace Charisma.Infrastructure.Persistence.SQLEF.Repository;

public class CartRepository : ICartRepository
{
	private readonly IDbContextFactory<OrderDbContext> _contextFactory;

	public CartRepository(IDbContextFactory<OrderDbContext> contextFactory)
	{
		_contextFactory = contextFactory;
	}

	public async Task<Guid> CreateAsync(Cart entity)
	{
		using var context = _contextFactory.CreateDbContext();
		var newEntity = await context.Carts.AddAsync(entity);
		await context.SaveChangesAsync();
		return newEntity.Entity.Id;
	}

	public async Task DeleteAsync(Guid id)
	{
		using var context = _contextFactory.CreateDbContext();
		context.Remove(id);
		await context.SaveChangesAsync();
	}

	public async Task<IEnumerable<Cart>> GetAllAsync()
	{
		using var context = _contextFactory.CreateDbContext();
		return await context.Carts
			.Include(c => c.CartItems)
		.ToListAsync();
	}

	public async Task<Cart?> GetByIdAsync(Guid id)
	{
		using var context = _contextFactory.CreateDbContext();
		return await context.Carts
			.Include(c => c.CartItems)
				.ThenInclude(i => i.Product)
			.FirstOrDefaultAsync(c => c.Id == id);
	}

	public async Task UpdateAsync(Cart cart)
	{
	 	var fetchedCart = await GetByIdAsync(cart.Id);

		if (cart == null)
			throw new ArgumentException("Order not found.");

		var itemsToRemove = fetchedCart!.CartItems.Except(cart.CartItems).ToList();
		foreach (var item in itemsToRemove)
		{
			cart.CartItems.Remove(item);
		}

		var itemsToAdd = cart.CartItems.Except(fetchedCart.CartItems).ToList();
		foreach (var item in itemsToAdd)
		{
			cart.CartItems.Add(item);
		}

		using var context = _contextFactory.CreateDbContext();
		context.Update(cart);
		await context.SaveChangesAsync();
	}
}
