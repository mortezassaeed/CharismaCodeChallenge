using Charisma.Order.Domain.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Charisma.Infrastructure.Persistence.SQLEF.Mappings;

internal class ProductConfiguration : IEntityTypeConfiguration<Product>
{
	public void Configure(EntityTypeBuilder<Product> builder)
	{
		builder.ToTable("Products")
			.HasKey(m => m.Id);

		builder.Property(m => m.Id).ValueGeneratedOnAdd();

		builder.Property(m => m.Name).HasMaxLength(100);
		builder.HasData(new Product("Product 1") { Id = 1 }, new Product("Product 2") { Id = 2 });
	}
}


