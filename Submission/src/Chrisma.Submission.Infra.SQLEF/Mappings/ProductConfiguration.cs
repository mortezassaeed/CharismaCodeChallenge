using Charisma.Submission.Domain.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Charisma.Submission.Infra.SQLEF.Mappings;

internal class ProductConfiguration : IEntityTypeConfiguration<Product>
{
	public void Configure(EntityTypeBuilder<Product> builder)
	{
		builder.ToTable("Products");
		builder.HasKey(x => x.Id);

		builder.Property(m => m.Type).HasConversion(
				v => v.ToString(),
				v => (ProductType)Enum.Parse(typeof(ProductType), v)).HasMaxLength(30);

		builder.HasData(
			new Product() { Id = 1, ProductCode = "P_1", Type = ProductType.Normal },
			new Product() { Id = 2, ProductCode = "P_2", Type = ProductType.Breakable }
			);
	}
}
