using Charisma.Framework.Domain.CommonValueObject;
using Charisma.Pricing.Domain.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Charisma.Pricing.Infra.Persistence.SQlEF.Mappings;

internal class ProductConfiguration : IEntityTypeConfiguration<Product>
{
	public void Configure(EntityTypeBuilder<Product> builder)
	{
		builder.ToTable("Product");
		builder.HasKey("Id");

		
		builder.OwnsOne(m => m.BasePrice, b =>
		{
			b.Property(m => m.Value).HasColumnName("Base_Price_Amount");
			b.Property(m => m.CurrencyType).HasColumnName("Base_Price_CurrencyType").HasConversion(
				v => v.ToString(),
				v => (CurrencyType)Enum.Parse(typeof(CurrencyType), v)).HasMaxLength(10);
		});
	}
}
