using Charisma.Submission.Domain.ProductAggregate;
using Charisma.Submission.Domain.SubmissionAggregate;
using Charisma.Submission.Infra.SQLEF.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Charisma.Submission.Infra.SQLEF;

public class SubmissionDbContext : DbContext
{
	public DbSet<Product> Product { get; set; }
	public DbSet<OrderSubmission> SubmissionOrder { get; set; }

	public SubmissionDbContext(DbContextOptions<SubmissionDbContext> options) : base(options)
	{

	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		base.OnConfiguring(optionsBuilder);
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.HasDefaultSchema("Submission");
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductConfiguration).Assembly);
		modelBuilder.HasChangeTrackingStrategy(ChangeTrackingStrategy.Snapshot);
		base.OnModelCreating(modelBuilder);
	}

}
