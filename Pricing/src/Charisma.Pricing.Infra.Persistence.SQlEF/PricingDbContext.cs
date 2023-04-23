using Charisma.Pricing.Domain.PricingAggregate;
using Charisma.Pricing.Domain.ProductAggregate;
using Charisma.Pricing.Infra.Persistence.SQlEF.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Charisma.Pricing.Infra.Persistence.SQlEF;

internal class PricingDbContext : DbContext
{
	public DbSet<ProductPricing> Pricing { get; set; }
	public DbSet<Product> Products { get; set; }

	public PricingDbContext(DbContextOptions<PricingDbContext> options) : base(options)
	{

	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		base.OnConfiguring(optionsBuilder);
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.HasDefaultSchema("Pricing");
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductConfiguration).Assembly);
		modelBuilder.HasChangeTrackingStrategy(ChangeTrackingStrategy.Snapshot);
		base.OnModelCreating(modelBuilder);
	}

}
