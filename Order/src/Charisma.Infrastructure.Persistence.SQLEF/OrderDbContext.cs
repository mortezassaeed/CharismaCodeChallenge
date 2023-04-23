using Charisma.Infrastructure.Persistence.SQLEF.Mappings;
using Charisma.Order.Domain.CartAggregate;
using Charisma.Order.Domain.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Charisma.Infrastructure.Persistence.SQLEF;

public class OrderDbContext : DbContext
{
	public DbSet<Cart> Carts { get; set; }
	public DbSet<Product> Products { get; set; }

	public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
	{

	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		base.OnConfiguring(optionsBuilder);
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(CartConfiguration).Assembly);
		modelBuilder.HasChangeTrackingStrategy(ChangeTrackingStrategy.Snapshot);
		base.OnModelCreating(modelBuilder);
	}
}